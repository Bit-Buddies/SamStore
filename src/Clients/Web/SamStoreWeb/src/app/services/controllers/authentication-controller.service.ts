import { UserData } from "../../models/user-data";
import { LoginData } from "../../models/login-data";
import { RegisterUserData } from "../../models/register-user-data";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { ApiServiceEnum, BaseApiService } from "../abstractions/base.service";
import { environment } from "src/environments/environment";

@Injectable({
	providedIn: "root",
})
export class AuthenticationControllerService extends BaseApiService {
	constructor(private _httpClient: HttpClient) {
		super(environment.AUTHENTICATION_API_BASE_URL);
	}

	registerUser(registerData: RegisterUserData): Observable<UserData> {
		return this._httpClient.post<UserData>(`${this._baseURL}authentication/register`, registerData);
	}

	login(loginData: LoginData): Observable<UserData> {
		return this._httpClient.post<UserData>(`${this._baseURL}authentication/authenticate`, loginData);
	}
}
