import { UserData } from "./../models/user-data";
import { Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";

@Injectable({
    providedIn: "root",
})
export class AccountService {
    private _userCookieToken = "CURRENT_USER";

    constructor(private _cookieService: CookieService) {}

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
}
