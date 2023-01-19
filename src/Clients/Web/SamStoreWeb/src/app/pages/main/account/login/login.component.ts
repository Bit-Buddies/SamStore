import { Router } from "@angular/router";
import { GlobalEventsService } from "./../../../../services/events/global-events.service";
import { LoginData } from "./../../../../models/login-data";
import { AccountService } from "./../../../../services/account.service";
import { AuthService } from "./../../../../services/auth.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Component } from "@angular/core";

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
    private _authService: AuthService,
    private _accountService: AccountService
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

    this._authService.login(this.loginData).subscribe((userData) => {
      this._accountService.setCurrentUser(userData);
      this._router.navigate(["/home"]);

      GlobalEventsService.userLoggedIn.emit();
    });
  }

  getControlError(controlName: string, errorCode: string) {
    return this.loginForm.controls[controlName].hasError(errorCode);
  }
}
