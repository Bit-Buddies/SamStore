import { Router } from "@angular/router";
import { Component } from "@angular/core";
import { LoadingService } from "src/app/services/loading.service";

@Component({
	selector: "app-login",
	templateUrl: "./login.component.html",
	styleUrls: ["./login.component.scss"],
})
export class LoginComponent {
	constructor(private _router: Router, private _loadingService: LoadingService) {}

	public onLoginCompleted(success: boolean) {
		if (!success) return;

		this._router.navigate(["/home"]);
	}

	public onButtonToChangeEvent() {
		if (this._loadingService.isLoading()) return;

		this._router.navigate(["/account/register"]);
	}
}
