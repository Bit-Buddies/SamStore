import { OnInit } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { Component } from "@angular/core";
import { AccountService } from "src/app/services/account.service";

@Component({
	selector: "app-authentication-modal",
	templateUrl: "./authentication-modal.component.html",
	styleUrls: ["./authentication-modal.component.scss"],
})
export class AuthenticationModalComponent implements OnInit {
	public modalToShow: "LOGIN" | "REGISTER" = "LOGIN";

	constructor(
		private _accountService: AccountService,
		private _dialogRef: MatDialogRef<AuthenticationModalComponent, boolean>
	) {}

	ngOnInit(): void {
		if (this._accountService.isLogged()) this._dialogRef.close(true);
	}

	public onLoginCompleted(success: boolean) {
		if (!success) return;
		this._dialogRef.close(true);
	}

	public onChangeModalToShow(modalToShow: "LOGIN" | "REGISTER") {
		this.modalToShow = modalToShow;
	}
}
