import { OnInit } from "@angular/core";
import { Component, Output, EventEmitter } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Subject, takeUntil } from "rxjs";
import { IBaseComponent } from "src/app/interfaces/base-component.interface";
import { LoginData } from "src/app/models/login-data";
import { ResponseApiError } from "src/app/models/response-api-error";
import { AccountService } from "src/app/services/account.service";
import { AuthenticationControllerService } from "src/app/services/controllers/authentication-controller.service";
import { GlobalEventsService } from "src/app/services/events/global-events.service";
import { FormErrorsService } from "src/app/services/form-errors.service";
import { LoadingService } from "src/app/services/loading.service";

@Component({
	selector: "app-login-core",
	templateUrl: "./login-core.component.html",
	styleUrls: ["./login-core.component.scss"],
})
export class LoginCoreComponent implements OnInit, IBaseComponent {
	@Output() public onLoginCompletedEvent: EventEmitter<boolean> = new EventEmitter<boolean>();
	@Output() public onButtonToChangeEvent: EventEmitter<void> = new EventEmitter<void>();

	public loginForm!: FormGroup;
	public loginData!: LoginData;
	public hidePassword: boolean = true;
	public formErrorsService: FormErrorsService = new FormErrorsService();

	unsubscribeAll$: Subject<void> = new Subject<void>;

	constructor(
		private _formBuilder: FormBuilder,
		private _authenticationService: AuthenticationControllerService,
		private _accountService: AccountService,
		private _toastrService: ToastrService,
		private _globalEventService: GlobalEventsService,
		public loadingService: LoadingService
	) { }

	ngOnDestroy(): void {
		this.unsubscribeAll$.next();
		this.unsubscribeAll$.complete();
	}

	ngOnInit(): void {
		this.loginForm = this._formBuilder.group({
			email: ["", [Validators.required, Validators.email]],
			password: ["", Validators.required],
		});

		this.loadingService.onLoadingChange
			.pipe(takeUntil(this.unsubscribeAll$))
			.subscribe({
				next: (isLoading) => {
					if (isLoading) this.loginForm.disable();
					else this.loginForm.enable();
				}});
	}

	login() {
		this.formErrorsService.clearErrors();

		if (!this.loginForm.dirty && this.loginForm.invalid) {
			return;
		}

		this.loginData = { ...this.loginData, ...this.loginForm.value };

		this._authenticationService.login(this.loginData)
			.pipe(takeUntil(this.unsubscribeAll$))
			.subscribe({
				next: (userData) => {
					this._accountService.setCurrentUser(userData);

					this._globalEventService.userLoggedIn.next();

					this.onLoginCompletedEvent.emit(true);
				},
				error: (response) => {
					const errors = this._authenticationService.extractErrors(response);

					if (!!errors.errors) {
						this.formErrorsService.errors = errors.errors.ErrorMessages;
					} else
						this._toastrService.error("An error has ocourred", undefined, {
							positionClass: "toast-bottom-right",
						});

					this.onLoginCompletedEvent.emit(false);
				}});
	}

	getControlError(controlName: string, errorCode: string) {
		return this.loginForm.controls[controlName].hasError(errorCode);
	}
}
