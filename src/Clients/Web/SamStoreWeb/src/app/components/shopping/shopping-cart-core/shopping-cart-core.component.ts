import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { ToastrService } from "ngx-toastr";
import { ProductDTO } from "src/app/models/Products/product.DTO";
import { ShoppingCartItemDTO } from "src/app/models/ShoppingCarts/shopping-cart-item.DTO";
import { AccountService } from "src/app/services/account.service";
import { ModalDialogComponent } from "src/app/utils/modal-dialog";

@Component({
  selector: "app-shopping-cart-core",
  templateUrl: "./shopping-cart-core.component.html",
  styleUrls: ["./shopping-cart-core.component.scss"],
})
export class ShoppingCartCoreComponent extends ModalDialogComponent {
  public items: ShoppingCartItemDTO[] = [];

  constructor(public dialogRef: MatDialogRef<ShoppingCartCoreComponent>, private _accountService: AccountService) {
    super();
  }

  public chamarModal(){
    this._accountService.callLoginModal();
  }
}
