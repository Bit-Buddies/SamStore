import { HttpClient } from "@angular/common/http";
import { ProductDTO } from "../../models/Products/product.DTO";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { ApiServiceEnum, BaseApiService } from "../abstractions/base.service";
import { environment } from "src/environments/environment";

@Injectable({
	providedIn: "root",
})
export class CatalogControllerService extends BaseApiService {
	constructor(private _httpClient: HttpClient) {
		super(environment.CATALOG_API_BASE_URL);
	}

	getAllProducts(): Observable<Array<ProductDTO>> {
		return this._httpClient.get<Array<ProductDTO>>(`${this._baseURL}catalog/products`);
	}

	getById(productId: string): Observable<ProductDTO> {
		return this._httpClient.get<ProductDTO>(`${this._baseURL}catalog/products/${productId}`);
	}
}
