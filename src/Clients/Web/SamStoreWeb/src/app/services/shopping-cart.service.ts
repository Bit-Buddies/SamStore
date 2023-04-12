import { OnInit } from "@angular/core";
import { Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { ShoppingCartDTO } from "../models/ShoppingCarts/shopping-cart.DTO";
import { AccountService } from "./account.service";
import { ProductDTO } from "../models/Products/product.DTO";

@Injectable({
    providedIn: "root",
})
export class ShoppingCartService {
    public shoppingCart?: ShoppingCartDTO;
    public shoppingCartCookieToken: string = "SHOPPING_CART";

    constructor(private _accountService: AccountService, private _cookieService: CookieService) {}

    public init(): void {
        if (this._accountService.getCurrentUser() == null) {
            this.getShoppingCartFromCookies();
        } else {
            this.getShoppingCartFromCookies();
        }
    }

    public addItem(product: ProductDTO, quantity: number) {
        if (this.shoppingCart != null)
            this.shoppingCart.items.push({
                productId: product.id,
                imagePath: product.image,
                name: product.name,
                quantity: quantity,
                price: product.value,
            });
    }

    public updateItem(product: ProductDTO, quantity: number) {
        if (this.shoppingCart != null) {
            const oldProduct = this.shoppingCart.items.find((i) => i.productId == product.id);

            if (oldProduct == null) {
                this.addItem(product, quantity);
                return;
            }

            const oldProductIndex = this.shoppingCart.items.indexOf(oldProduct);
            this.shoppingCart.items[oldProductIndex].quantity = quantity;
        }
    }

    public removeItem(productId: string) {
        if (this.shoppingCart != null)
            this.shoppingCart.items = this.shoppingCart.items.filter((item) => item.productId != productId);
    }

    public clearShoppingCart(){
        if (this.shoppingCart != null){
            this.shoppingCart.items = [];
        }
    }

    private getShoppingCartFromCookies(){
        const cookieShoppingCart = this._cookieService.get(this.shoppingCartCookieToken);

        if (cookieShoppingCart == null || cookieShoppingCart.length <= 0) {
            this.shoppingCart = new ShoppingCartDTO();
            this._cookieService.set(this.shoppingCartCookieToken, JSON.stringify(this.shoppingCart));
            return;
        }
        const oldShoppingCart = JSON.parse(cookieShoppingCart) as ShoppingCartDTO;

        this.shoppingCart = oldShoppingCart == null ? new ShoppingCartDTO() : oldShoppingCart;
    }
}
