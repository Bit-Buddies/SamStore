import { Observable } from "rxjs";
import { UserData } from "./../models/user-data";
import { Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { DialogService } from "../utils/dialog-service";
import { LoginModalComponent } from "../components/authentication/login-modal/login-modal.component";
import * as moment from "moment";

@Injectable({
	providedIn: "root",
})
export class AccountService {
	private _userToken = "CURRENT_USER";

	constructor(private _dialogService: DialogService) {}

	public getCurrentUser(): UserData | null {
		const userJson = localStorage.getItem(this._userToken);

		if (userJson == null || userJson == "") return null;

		return JSON.parse(userJson) as UserData;
	}

	public setCurrentUser(userData: UserData) {
		let user = this.getCurrentUser();

		if (user != null) {
			this.removeCurrentUser();
		}

		const userJson = JSON.stringify(userData);

		localStorage.setItem(this._userToken, userJson);
	}

	public removeCurrentUser() {
		localStorage.removeItem(this._userToken);
	}

	public isLogged(): boolean {
		return !!this.getCurrentUser();
	}

	public callLogin(): Observable<boolean> {
		return this._dialogService.genericDialog<LoginModalComponent, any, boolean>(LoginModalComponent, {
			panelClass: "xs-dialog",
		});
	}
}
