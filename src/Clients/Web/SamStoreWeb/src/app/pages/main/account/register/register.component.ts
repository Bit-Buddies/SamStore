import { AuthService } from './../../../../services/auth.service';
import { RegisterUserData } from './../../../../models/register-user-data';
import { Component, OnInit, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit, AfterViewInit {
  registerForm!: FormGroup;
  registerUserData!: RegisterUserData;
  hidePassword = true;

  constructor(
    private _formBuilder: FormBuilder,
    private _authService: AuthService
  ) {}

  ngOnInit(): void {
    this.registerForm = this._formBuilder.group({
      email: [''],
      password: [''],
      repeatPassword: [''],
    });
  }

  ngAfterViewInit(): void {}

  public registerUser() {
    if (!this.registerForm.dirty || !this.registerForm.valid) return;

    Object.assign({}, this.registerUserData, ...this.registerForm.value);

    this._authService.registerUser(this.registerUserData);
  }
}
