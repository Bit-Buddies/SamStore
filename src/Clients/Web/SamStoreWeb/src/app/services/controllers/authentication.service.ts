import { UserData } from "../../models/user-data";
import { LoginData } from "../../models/login-data";
import { RegisterUserData } from "../../models/register-user-data";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { map, catchError, Observable } from "rxjs";
import { BaseApiService } from "../abstractions/base.service";

@Injectable({
  providedIn: "root",
})
export class AuthenticationService extends BaseApiService {
  constructor(private _httpClient: HttpClient) {
    super("auth", "Identity");
  }

  registerUser(registerData: RegisterUserData): Observable<UserData> {
    return this._httpClient.post<UserData>(this._baseURL + "/register", registerData);
  }

  login(loginData: LoginData): Observable<UserData> {
    return this._httpClient.post<UserData>(this._baseURL + "/authenticate", loginData);
  }
}
