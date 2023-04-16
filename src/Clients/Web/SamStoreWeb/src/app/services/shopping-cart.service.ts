import { OnInit } from "@angular/core";
import { Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { ShoppingCartDTO } from "../models/ShoppingCarts/shopping-cart.DTO";
import { AccountService } from "./account.service";
import { ProductDTO } from "../models/Products/product.DTO";
import { ShoppingCartCoreComponent } from "../components/shopping/shopping-cart-core/shopping-cart-core.component";
import { DialogService } from "../utils/dialog-service";
import { ShoppingCartControllerService } from "./controllers/shopping-cart-controller.service";
import { lastValueFrom } from "rxjs";

@Injectable({
	providedIn: "root",
})
export class ShoppingCartService {
	public shoppingCart?: ShoppingCartDTO;
	public shoppingCartCookieToken: string = "SHOPPING_CART";

	constructor(
		private _accountService: AccountService,
		private _cookieService: CookieService,
		private _dialogService: DialogService,
		private _shoppingCartControllerService: ShoppingCartControllerService
	) {}

	public init() {
		if (!this._accountService.isLogged()) {
			this.getShoppingCartFromCookies();
			return;
		}

		this._shoppingCartControllerService.getCart().subscribe({
			next: (cart) => {
				if (!!cart) {
					this.shoppingCart = cart;
					this.updateShoppingCartIntoCookies();
					return;
				}

				this.getShoppingCartFromCookies();
			},
			error: () => {
				this.getShoppingCartFromCookies();
			},
		});
	}

	private addItem(product: ProductDTO, quantity: number) {
		if (this.shoppingCart != null) {
			this.shoppingCart.items.push({
				productId: product.id,
				imagePath: product.image,
				name: product.name,
				quantity: quantity,
				price: product.value,
			});

			this.updateShoppingCartIntoCookies();
		}
	}

	public addOrUpdateItem(product: ProductDTO, quantity: number) {
		try {
			if (this.shoppingCart != null) {
				const oldProduct = this.shoppingCart.items.find((i) => i.productId == product.id);

				if (oldProduct == null) {
					this.addItem(product, quantity);
					return;
				}

				const oldProductIndex = this.shoppingCart.items.indexOf(oldProduct);
				this.shoppingCart.items[oldProductIndex].quantity += quantity;

				this.updateShoppingCartIntoCookies();
			}
		} finally {
			if (this._accountService.isLogged()) {
				this._shoppingCartControllerService.updateCart(this.shoppingCart!).subscribe();
			}
		}
	}

	public removeItem(productId: string) {
		if (this.shoppingCart != null) {
			this.shoppingCart.items = this.shoppingCart.items.filter((item) => item.productId != productId);

			this.updateShoppingCartIntoCookies();
		}
	}

	public clearShoppingCart() {
		if (this.shoppingCart != null) {
			this.shoppingCart.items = [];

			this.updateShoppingCartIntoCookies();
		}
	}

	private getShoppingCartFromCookies() {
		const cookieShoppingCart = this._cookieService.get(this.shoppingCartCookieToken);

		if (cookieShoppingCart == null || cookieShoppingCart.length <= 0) {
			this.shoppingCart = new ShoppingCartDTO();
			this._cookieService.set(this.shoppingCartCookieToken, JSON.stringify(this.shoppingCart));
			return;
		}
		const oldShoppingCart = JSON.parse(cookieShoppingCart) as ShoppingCartDTO;

		this.shoppingCart = oldShoppingCart == null ? new ShoppingCartDTO() : oldShoppingCart;
	}

	private updateShoppingCartIntoCookies() {
		this._cookieService.deleteAll(this.shoppingCartCookieToken);

		let totalValue = 0;

		if (this.shoppingCart!.items.length > 0)
			totalValue = this.shoppingCart!.items.reduce((total, item) => (total += item.price * item.quantity), 0);

		this.shoppingCart!.total = totalValue;

		this._cookieService.set(this.shoppingCartCookieToken, JSON.stringify(this.shoppingCart));
	}

	public openShoppingCartModal() {
		this._dialogService.genericDialog(ShoppingCartCoreComponent, {
			autoFocus: false,
			panelClass: "shopping-cart-container",
		});
	}

	public getTotalQuantity() {
		if (!this.shoppingCart?.items.length) return 0;

		return this.shoppingCart.items.reduce((total, item) => (total += item.quantity), 0);
	}
}
