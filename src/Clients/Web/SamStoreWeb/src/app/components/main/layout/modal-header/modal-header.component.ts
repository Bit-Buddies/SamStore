import { EventEmitter } from '@angular/core';
import { Component, Input, Output } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ModalDialogComponent } from 'src/app/utils/modal-dialog';

@Component({
  selector: 'app-modal-header',
  templateUrl: './modal-header.component.html',
  styleUrls: ['./modal-header.component.scss']
})
export class ModalHeaderComponent {
  @Input() title: string = "";
  @Input() useExitButton: boolean = true;
  @Input() matDialogRef?: MatDialogRef<ModalDialogComponent>;

  public onExitButtonPressed(){
    this.matDialogRef?.close();
  }
}
