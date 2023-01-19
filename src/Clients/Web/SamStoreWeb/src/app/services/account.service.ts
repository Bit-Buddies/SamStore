import { UserData } from "./../models/user-data";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class AccountService {
  private _currentUserName = "current-user";

  getCurrentUser(): UserData | null {
    const userJson = localStorage.getItem(this._currentUserName);

    if (userJson == null) return null;

    return JSON.parse(userJson) as UserData;
  }

  setCurrentUser(userData: UserData) {
    let user = this.getCurrentUser();

    if (user != null) {
      this.removeCurrentUser();
    }

    const userJson = JSON.stringify(userData);

    localStorage.setItem(this._currentUserName, userJson);
  }

  removeCurrentUser() {
    localStorage.removeItem(this._currentUserName);
  }
}
