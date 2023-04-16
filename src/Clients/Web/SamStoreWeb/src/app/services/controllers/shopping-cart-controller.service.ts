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

	public clearCart(): Observable<void> {
		return this._httpClient.delete<void>(`${this._baseURL}/clear`);
	}

	public addItem(item: ShoppingCartItemDTO): Observable<void> {
		return this._httpClient.post<void>(`${this._baseURL}`, item);
	}

	public removeItem(productId: string): Observable<void> {
		const params = new HttpParams().set("productId", productId);

		return this._httpClient.delete<void>(`${this._baseURL}`, { params: params });
	}
}
