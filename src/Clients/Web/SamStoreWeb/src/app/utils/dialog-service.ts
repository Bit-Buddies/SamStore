import { ComponentType } from "@angular/cdk/portal";
import { Component, Injectable, TemplateRef } from "@angular/core";
import { MatDialog, MatDialogConfig } from "@angular/material/dialog";
import { Observable } from "rxjs";
import { ConfirmationDialogComponent } from "../components/main/confirmation-dialog/confirmation-dialog.component";

export interface ConfirmationDialogData {
	title?: string;
	description: string;
	positiveButtonDescription: string;
	negativeButtonDescription: string;
	positiveFunction: () => void;
	negativeFunction: () => void;
}

@Injectable({ providedIn: "root" })
export class DialogService {
	constructor(private dialogService: MatDialog) {}

	public confirmationDialog(data: ConfirmationDialogData) {
		return this.dialogService.open(ConfirmationDialogComponent, {
			panelClass: "xs-dialog",
			data: data,
			autoFocus: false,
		});
	}

	public genericDialog<TComponent, TConfig = any, TResult = any>(
		componentRef: ComponentType<TComponent> | TemplateRef<TComponent>,
		config: MatDialogConfig<TConfig>
	): Observable<TResult> {
		config = {
			...config,
			enterAnimationDuration: 50,
			exitAnimationDuration: 50,
		};

		config.restoreFocus = false;
		return this.dialogService.open(componentRef, config).afterClosed();
	}
}
