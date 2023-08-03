import { ResponseApiError } from "./../../models/response-api-error";
import { HttpHeaders } from "@angular/common/http";

export enum ApiServiceEnum {
	Identity,
	Catalog,
	ShoppingCart,
}

export abstract class BaseApiService {
	protected _baseURL: string = "";

	constructor(protected baseUrl: string) {
		this._baseURL = baseUrl;
	}

	protected getApplicationJsonHeader() {
		return {
			headers: new HttpHeaders({
				"Content-Type": "application/json",
			}),
		};
	}

	public extractErrors(response: Response | any) {
		return response.error as ResponseApiError;
	}
}
