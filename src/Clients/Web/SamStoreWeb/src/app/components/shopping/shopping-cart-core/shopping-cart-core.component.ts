import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { Router } from "@angular/router";
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
	public displayedColumns = ["image", "details", "price", "total", "actions"];
	public loginAlert: boolean = false;

	constructor(
		private _accountService: AccountService,
		private _toastrService: ToastrService,
		private _dialogService: DialogService,
		public shoppingCartService: ShoppingCartService,
		public dialogRef: MatDialogRef<ShoppingCartCoreComponent>,
		private _router: Router
	) {
		super();
	}

	public onClickContinueButton() {
		this.dialogRef.close();
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
						this.loginAlert = true;
					}
				},
			});

			return;
		}

		//TODO REDIRECT TO PURCHASE PAGE
	}

	public redirectToProductDetails(productId: string) {
		this.dialogRef.afterClosed().subscribe(() => {
			this._router.navigate([`/product/details/${productId}`]);
		});

		this.dialogRef.close();
	}
}
