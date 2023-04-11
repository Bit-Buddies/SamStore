import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ModalDialogComponent } from 'src/app/utils/modal-dialog';

@Component({
  selector: 'app-shopping-cart-core',
  templateUrl: './shopping-cart-core.component.html',
  styleUrls: ['./shopping-cart-core.component.scss']
})
export class ShoppingCartCoreComponent extends ModalDialogComponent {
  public items: any[] = [];

  constructor(public dialogRef: MatDialogRef<ShoppingCartCoreComponent>) {
    super();
   }
}
