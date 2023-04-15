import { Input, OnInit } from "@angular/core";
import { Component, Inject } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { ConfirmationDialogData } from "src/app/utils/dialog-service";

@Component({
	selector: "app-confirmation-dialog",
	templateUrl: "./confirmation-dialog.component.html",
	styleUrls: ["./confirmation-dialog.component.scss"],
})
export class ConfirmationDialogComponent {
	constructor(
		@Inject(MAT_DIALOG_DATA) public data: ConfirmationDialogData,
		private _dialogRef: MatDialogRef<ConfirmationDialogComponent>
	) {}

	public onOptionClicked(functionToExecute: () => void) {
		this._dialogRef.afterClosed().subscribe({
			next: () => {
				functionToExecute();
			},
		});

		this._dialogRef.close();
	}
}
