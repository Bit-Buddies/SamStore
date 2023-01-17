import { LoginData } from './../models/login-data';
import { RegisterUserData } from '../models/register-user-data';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private _httpClient: HttpClient) {}

  registerUser(registerData: RegisterUserData) {}

  login(loginData: LoginData) {}
}
