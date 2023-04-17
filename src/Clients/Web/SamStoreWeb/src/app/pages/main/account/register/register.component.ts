import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { LoadingService } from "src/app/services/loading.service";

@Component({
	selector: "app-register",
	templateUrl: "./register.component.html",
	styleUrls: ["./register.component.scss"],
})
export class RegisterComponent {
	constructor(private _router: Router, private _loadingService: LoadingService) {}

	public onLoginCompleted(success: boolean) {
		if (!success) return;

		this._router.navigate(["/home"]);
	}

	public onButtonToChangeEvent() {
		if (this._loadingService.isLoading()) return;

		this._router.navigate(["/account/login"]);
	}
}
