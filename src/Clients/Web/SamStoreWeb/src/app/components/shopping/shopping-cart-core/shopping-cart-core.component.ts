import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { ToastrService } from "ngx-toastr";
import { ProductDTO } from "src/app/models/Products/product.DTO";
import { ShoppingCartItemDTO } from "src/app/models/ShoppingCarts/shopping-cart-item.DTO";
import { AccountService } from "src/app/services/account.service";
import { ShoppingCartService } from "src/app/services/shopping-cart.service";
import { DialogService } from "src/app/utils/dialog-service";
import { ModalDialogComponent } from "src/app/utils/modal-dialog";

@Component({
	selector: "app-shopping-cart-core",
	templateUrl: "./shopping-cart-core.component.html",
	styleUrls: ["./shopping-cart-core.component.scss"],
})
export class ShoppingCartCoreComponent extends ModalDialogComponent {
	constructor(
		private _accountService: AccountService,
		private _toastrService: ToastrService,
    private _dialogService: DialogService,
		public dialogRef: MatDialogRef<ShoppingCartCoreComponent>,
		public shoppingCartService: ShoppingCartService
	) {
		super();
	}

	public onClickClearButton() {
    this._dialogService

		this.dialogRef.close();
		this.shoppingCartService.clearShoppingCart();
		this._toastrService.success("Your shopping cart was successful cleared", undefined, { timeOut: 2000 });
	}
}
