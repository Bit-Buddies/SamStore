import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AccountService } from "../services/account.service";

@Injectable({
    providedIn: "root",
})
export class AuthenticationGuard implements CanActivate {
  constructor(private _accountService: AccountService) { }
    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        return this._accountService.isLogged();
    }
}
