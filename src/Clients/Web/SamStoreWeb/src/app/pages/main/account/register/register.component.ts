import { AccountService } from "./../../../../services/account.service";
import { GlobalEventsService } from "./../../../../services/events/global-events.service";
import { UserData } from "./../../../../models/user-data";
import { AuthService } from "./../../../../services/auth.service";
import { RegisterUserData } from "./../../../../models/register-user-data";
import { Component, OnInit, AfterViewInit } from "@angular/core";
import { AbstractControl, FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  hidePassword = true;

  private _registerData!: RegisterUserData;

  constructor(
    private _formBuilder: FormBuilder,
    private _authService: AuthService,
    private _accountService: AccountService,
    private _router: Router
  ) {}

  registerUser() {
    if (!this.registerForm.dirty || this.registerForm.invalid) return;

    this._registerData = { ...this._registerData, ...this.registerForm.value };

    this._authService.registerUser(this._registerData).subscribe((userData) => {
      this._accountService.setCurrentUser(userData);
      this._router.navigate(["/home"]);

      GlobalEventsService.userLoggedIn.emit();
    });
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

  ngOnInit(): void {
    this.registerForm = this._formBuilder.group({
      name: ["", Validators.compose([Validators.required, Validators.minLength(3)])],
      email: ["", Validators.compose([Validators.required, Validators.email])],
      password: ["", Validators.compose([Validators.required, Validators.minLength(6)])],
      repeatPassword: ["", Validators.compose([Validators.required])],
    });
  }
}
