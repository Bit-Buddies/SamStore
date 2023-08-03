import { ToastrService } from "ngx-toastr";
import { AccountService } from "src/app/services/account.service";
import { GlobalEventsService } from "src/app/services/events/global-events.service";
import { AuthenticationControllerService } from "src/app/services/controllers/authentication-controller.service";
import { RegisterUserData } from "src/app/models/register-user-data";
import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ValidateCPF } from "src/app/utils/custom-validators";
import { LoadingService } from "src/app/services/loading.service";
import { FormErrorsService } from "src/app/services/form-errors.service";
import { NgxMaskDirective, provideEnvironmentNgxMask, provideNgxMask } from "ngx-mask";
import { ONLY_NUMBER_REGEX } from "src/app/utils/regex-collection";
import { IBaseComponent } from "src/app/interfaces/base-component.interface";
import { Subject, takeUntil } from "rxjs";

@Component({
	selector: "app-register-core",
	templateUrl: "./register-core.component.html",
	styleUrls: ["./register-core.component.scss"]
})
export class RegisterCoreComponent implements OnInit, IBaseComponent {
	@Output() public onRegisterCompletedEvent: EventEmitter<boolean> = new EventEmitter<boolean>();
	@Output() public onButtonToChangeEvent: EventEmitter<void> = new EventEmitter<void>();

	public registerForm!: FormGroup;
	public hidePassword = true;
	public formErrorsService: FormErrorsService = new FormErrorsService();

	private _registerData!: RegisterUserData;

	public unsubscribeAll$: Subject<void> = new Subject();

	constructor(
		private _formBuilder: FormBuilder,
		private _authenticationService: AuthenticationControllerService,
		private _accountService: AccountService,
		private _toastrService: ToastrService,
		private _globalEventService: GlobalEventsService,
		public loadingService: LoadingService
	) {}

	ngOnDestroy(): void {
		this.unsubscribeAll$.next();
		this.unsubscribeAll$.complete();
	}

	ngOnInit(): void {
		this.loadingService.onLoadingChange
			.pipe(takeUntil(this.unsubscribeAll$))
			.subscribe({
				next: (isLoading) => {
					if (isLoading) this.registerForm.disable();
					else this.registerForm.enable();
				}});

		this.registerForm = this._formBuilder.group({
			name: [
				"",
				[
					Validators.required,
					Validators.minLength(3),
					Validators.maxLength(50),
					Validators.pattern(/^[a-zA-Z]{1,}(?: [a-zA-Z]+){0,4}$/),
				],
			],
			cpf: ["", [Validators.required, ValidateCPF()]],
			email: ["", [Validators.required, Validators.email]],
			password: [
				"",
				[
					Validators.required,
					Validators.minLength(8),
					Validators.pattern(/^(?=.*\d)(?=.*[a-z])(?=.*[a-zA-Z]).{8,}$/),
				],
			],
			repeatPassword: ["", [Validators.required]],
		});
	}

	registerUser() {
		this.formErrorsService.clearErrors();

		if (!this.registerForm.dirty || this.registerForm.invalid) {
			return;
		}

		this._registerData = { ...this._registerData, ...this.registerForm.value };

		this._authenticationService.registerUser(this._registerData)
			.pipe(takeUntil(this.unsubscribeAll$))
			.subscribe({
				next: (userData) => {
					this._accountService.setCurrentUser(userData);

					this._globalEventService.userLoggedIn.next();

					this.onRegisterCompletedEvent.emit(true);
				},
				error: (response) => {
					const errors = this._authenticationService.extractErrors(response);

					if (!!errors.errors) this.formErrorsService.errors = errors?.errors.ErrorMessages;
					else
						this._toastrService.error("An error has ocourred", undefined, {
							positionClass: "toast-bottom-right",
						});

					this.onRegisterCompletedEvent.emit(false);
				}});
	}

	getControlError(controlName: string, errorCode: string): boolean {
		return this.registerForm.controls[controlName].hasError(errorCode);
	}

	mustmatchValidator() {
		const passwordControl = this.registerForm.get("password")!;
		const repeatPasswordControl = this.registerForm.get("repeatPassword")!;

		if (!repeatPasswordControl.dirty && !repeatPasswordControl.touched) {
			return;
		}

		if (repeatPasswordControl.errors && !repeatPasswordControl.hasError("passwordMismatched")) {
			return;
		}

		if (passwordControl.value === repeatPasswordControl.value) {
			return repeatPasswordControl.setErrors(null);
		}

		return repeatPasswordControl.setErrors({ passwordMismatched: true });
	}

	onCPFInputChanges(event: any){
		const onlyNumbers = event.target.value.replace(ONLY_NUMBER_REGEX, "")
			.replace(/(\d{3})(\d)/, "$1.$2")
			.replace(/(\d{3})(\d)/, "$1.$2")
			.replace(/(\d{3})(\d{1,2})/, "$1-$2")
			.replace(/(-\d{2})\d+?$/, "$1");

		this.registerForm.get('cpf')?.patchValue(onlyNumbers);
	}
}
