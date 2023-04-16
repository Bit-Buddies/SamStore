import { Injectable } from "@angular/core";
import { ApiServiceEnum, BaseApiService } from "../abstractions/base.service";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { ShoppingCartDTO } from "src/app/models/ShoppingCarts/shopping-cart.DTO";
import { ShoppingCartItemDTO } from "src/app/models/ShoppingCarts/shopping-cart-item.DTO";

@Injectable({
	providedIn: "root",
})
export class ShoppingCartControllerService extends BaseApiService {
	constructor(private _httpClient: HttpClient) {
		super("ShoppingCart", ApiServiceEnum.ShoppingCart);
	}

	public getCart(): Observable<ShoppingCartDTO> {
		return this._httpClient.get<ShoppingCartDTO>(`${this._baseURL}`);
	}

	public updateCart(shoppingCart: ShoppingCartDTO) {
		return this._httpClient.put<void>(`${this._baseURL}`, shoppingCart);
	}
}
