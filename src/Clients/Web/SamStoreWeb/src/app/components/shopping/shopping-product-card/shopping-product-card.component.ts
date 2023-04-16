import { AccountService } from "src/app/services/account.service";
import { ProductDTO } from "./../../../models/Products/product.DTO";
import { Component, Input } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
	selector: "app-shopping-product-card",
	templateUrl: "./shopping-product-card.component.html",
	styleUrls: ["./shopping-product-card.component.scss"],
})
export class ShoppingProductCardComponent {
	@Input() public product?: ProductDTO;
	public isFavorite: boolean = false;

	constructor(
		private _router: Router,
		private _accountService: AccountService,
		private _toastrService: ToastrService,
		private _snackBar: MatSnackBar
	) {}

	public openProductDetails() {
		this._router.navigate([`/product/details/${this.product?.id}`]);
	}

	public favoriteProduct() {
		if (!this._accountService.isLogged()) {
			this._accountService.callLogin().subscribe({
				next: (success) => {
					if (success) {
						this.isFavorite = !this.isFavorite;

						this.showFavoriteToastrMessage;
					}
				},
			});

			return;
		} else {
			this.isFavorite = !this.isFavorite;
		}

		if (this.isFavorite) this.showFavoriteToastrMessage();
	}

	private showFavoriteToastrMessage() {
		this._snackBar.open(`${this.product?.name} added to your wishlist`, undefined, {
			duration: 1000,
		});
	}
}
