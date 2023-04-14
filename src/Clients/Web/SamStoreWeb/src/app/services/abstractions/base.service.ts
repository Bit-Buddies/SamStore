import { ResponseApiError } from "./../../models/response-api-error";
import { HttpHeaders } from "@angular/common/http";

export enum ApiServiceEnum {
  Identity,
  Catalog,
  ShoppingCart,
}

export abstract class BaseApiService {
  private _identityBaseURL: string = "http://localhost:5274/api/";
  private _catalogBaseURL: string = "http://localhost:5229/api/";
  private _shoppingCartBaseURL: string = "http://localhost:5137/api/";

  protected _baseURL: string = "";

  constructor(protected controllerName: string, api: ApiServiceEnum) {
    switch (api) {
      case ApiServiceEnum.Identity:
        this._baseURL = this._identityBaseURL;
        break;
      case ApiServiceEnum.Catalog:
        this._baseURL = this._catalogBaseURL;
        break;
      case ApiServiceEnum.ShoppingCart:
        this._baseURL = this._shoppingCartBaseURL;
    }

    this._baseURL += controllerName;
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
