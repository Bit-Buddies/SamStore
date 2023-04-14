import { Observable } from "rxjs";
import { UserData } from "./../models/user-data";
import { Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { DialogService } from "../utils/dialog-service";
import { LoginModalComponent } from "../components/authentication/login-modal/login-modal.component";

@Injectable({
    providedIn: "root",
})
export class AccountService {
    private _userCookieToken = "CURRENT_USER";

    constructor(private _cookieService: CookieService, private _dialogService: DialogService) {}

    public getCurrentUser(): UserData | null {
        const userJson = this._cookieService.get(this._userCookieToken);

        if (userJson == null || userJson == "") return null;

        return JSON.parse(userJson) as UserData;
    }

    public setCurrentUser(userData: UserData) {
        let user = this.getCurrentUser();

        if (user != null) {
            this.removeCurrentUser();
        }

        const userJson = JSON.stringify(userData);

        this._cookieService.set(this._userCookieToken, userJson);
    }

    public removeCurrentUser() {
        this._cookieService.delete(this._userCookieToken);
    }

    public isLogged(): boolean {
        return !!this.getCurrentUser();
    }

    public callLoginModal(): Observable<boolean> {
        return this._dialogService.genericDialog<LoginModalComponent, any, boolean>(LoginModalComponent, {
            width: "340px",
            height: "350px",
        });
    }
}
