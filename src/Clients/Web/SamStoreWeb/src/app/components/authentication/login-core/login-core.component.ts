import { Component, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginData } from 'src/app/models/login-data';
import { AccountService } from 'src/app/services/account.service';
import { AuthenticationControllerService } from 'src/app/services/controllers/authentication-controller.service';
import { GlobalEventsService } from 'src/app/services/events/global-events.service';

@Component({
  selector: 'app-login-core',
  templateUrl: './login-core.component.html',
  styleUrls: ['./login-core.component.scss']
})
export class LoginCoreComponent {
  @Output() public onLoginCompletedEvent: EventEmitter<boolean> = new EventEmitter<boolean>();

  loginForm!: FormGroup;
  loginData!: LoginData;
  hidePassword: boolean = true;

  constructor(
    private _formBuilder: FormBuilder,
    private _router: Router,
    private _authenticationService: AuthenticationControllerService,
    private _accountService: AccountService,
    private _toastrService: ToastrService,
    private _globalEventService: GlobalEventsService
  ) {
    this.loginForm = _formBuilder.group({
      email: ["", Validators.compose([Validators.required, Validators.email])],
      password: ["", Validators.required],
    });
  }

  login() {
    if (!this.loginForm.dirty && this.loginForm.invalid) {
      return;
    }

    this.loginData = { ...this.loginData, ...this.loginForm.value };

    this._authenticationService.login(this.loginData).subscribe({
      next: (userData) => {
        this._accountService.setCurrentUser(userData);
        this._globalEventService.userLoggedIn.next();

        this.onLoginCompletedEvent.emit(true);
      },
      error: (response) => {
        const errors = this._authenticationService.extractErrors(response);

        errors.errors.Mensagens.forEach((er) => {
          this._toastrService.error(er, undefined, {
            positionClass: "toast-bottom-right",
          });
        });

        this.onLoginCompletedEvent.emit(false);
      },
    });
  }

  getControlError(controlName: string, errorCode: string) {
    return this.loginForm.controls[controlName].hasError(errorCode);
  }
}
