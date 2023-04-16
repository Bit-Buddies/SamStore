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
	public displayedColumns = ["image", "details", "total", "actions"];

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
		this._dialogService.confirmationDialog({
			description: "Are you sure you want to clear your cart?",
			title: "Clear",
			positiveButtonDescription: "Yes",
			negativeButtonDescription: "Cancel",
			negativeFunction: () => {},
			positiveFunction: () => {
				this.dialogRef.afterClosed().subscribe({
					next: () => {
						this.shoppingCartService.clearShoppingCart();
						this._toastrService.success("Your shopping cart was successful cleared", undefined, {
							timeOut: 2000,
						});
					},
				});

				this.dialogRef.close();
			},
		});
	}

	public onClickRemoveItem(item: ShoppingCartItemDTO) {
		this.shoppingCartService.removeItem(item.productId);
	}

	public checkout() {
		if (!this._accountService.isLogged()) {
			this._accountService.callLogin().subscribe({
				next: (success: boolean) => {
					if (success) {
						//TODO REDIRECT TO PURCHASE PAGE
					} else {
						this._toastrService.warning("To proceed with your purchase you need to login");
					}
				},
			});

			return;
		}

		//TODO REDIRECT TO PURCHASE PAGE
	}
}
