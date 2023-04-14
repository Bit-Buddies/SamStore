import { OnInit } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { Component } from "@angular/core";
import { AccountService } from "src/app/services/account.service";

@Component({
    selector: "app-login-modal",
    templateUrl: "./login-modal.component.html",
    styleUrls: ["./login-modal.component.scss"],
})
export class LoginModalComponent implements OnInit {
    constructor(
        private _accountService: AccountService,
        private _dialogRef: MatDialogRef<LoginModalComponent, boolean>
    ) {}

    ngOnInit(): void {
      if(this._accountService.isLogged())
        this._dialogRef.close(true);
    }

    public onLoginCompleted(success: boolean) {
        if (!success) return;
        this._dialogRef.close(true);
    }
}
