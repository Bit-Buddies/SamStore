import { EventEmitter } from '@angular/core';
import { Component, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal-header',
  templateUrl: './modal-header.component.html',
  styleUrls: ['./modal-header.component.scss']
})
export class ModalHeaderComponent {
  @Input() title: string = "";
  @Input() useExitButton: boolean = true;
  @Output() onExitbuttonPressed: EventEmitter<void> = new EventEmitter();
}
