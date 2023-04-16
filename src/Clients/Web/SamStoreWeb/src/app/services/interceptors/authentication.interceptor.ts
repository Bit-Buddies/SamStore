import { Observable } from "rxjs";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AccountService } from "../account.service";
@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
	/**
	 *
	 */
	constructor(private _accountService: AccountService) {}

	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		const user = this._accountService.getCurrentUser();

		if (user == null) {
			return next.handle(req);
		}

		const reqAuthenticated = req.clone({
			headers: req.headers.set("Authorization", `Bearer ${user.accessToken}`),
		});

		return next.handle(reqAuthenticated);
	}
}
