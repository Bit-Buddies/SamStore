import { Router } from "@angular/router";
import { GlobalEventsService } from "./../../../../services/events/global-events.service";
import { LoginData } from "./../../../../models/login-data";
import { AccountService } from "./../../../../services/account.service";
import { AuthenticationService } from "../../../../services/authentication.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Component } from "@angular/core";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent {
  loginForm!: FormGroup;
  loginData!: LoginData;
  hidePassword: boolean = true;

  /**
   *
   */
  constructor(
    private _formBuilder: FormBuilder,
    private _router: Router,
    private _authenticationService: AuthenticationService,
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
        this._router.navigate(["/home"]);

        this._globalEventService.userLoggedIn.next();
      },
      error: (response) => {
        const errors = this._authenticationService.extractErrors(response);

        errors.errors.Mensagens.forEach((er) => {
          this._toastrService.error(er, undefined, {
            positionClass: "toast-bottom-right",
          });
        });
      },
    });
  }

  getControlError(controlName: string, errorCode: string) {
    return this.loginForm.controls[controlName].hasError(errorCode);
  }
}
