import { ComponentType } from "@angular/cdk/portal";
import { Component, Injectable, TemplateRef } from "@angular/core";
import { MatDialog, MatDialogConfig } from "@angular/material/dialog";
import { Observable } from "rxjs";

@Injectable({providedIn: "root"})
export class DialogService {
  constructor(private dialogService: MatDialog){}

  public genericDialog<TComponent, TConfig = any, TResult = any>(
    componentRef: ComponentType<TComponent> | TemplateRef<TComponent>,
    config: MatDialogConfig<TConfig>
  ): Observable<TResult> {
      config.restoreFocus = false;
      config.disableClose = config?.disableClose || true;

      return this.dialogService.open(componentRef, config).afterClosed();
  }
}
