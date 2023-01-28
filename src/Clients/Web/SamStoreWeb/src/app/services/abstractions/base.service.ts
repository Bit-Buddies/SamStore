import { ResponseApiError } from "./../../models/response-api-error";
import { HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { ErrorStateMatcher } from "@angular/material/core";
import { throwError } from "rxjs";

export abstract class BaseApiService {
  private _identityBaseURL: string = "http://localhost:5274/api/";
  private _catalogBaseURL: string = "http://localhost:5229/api/";
  protected _baseURL: string = "";

  constructor(protected controllerName: string, api: "Identity" | "Catalog") {
    switch (api) {
      case "Identity":
        this._baseURL = this._identityBaseURL;
        break;
      case "Catalog":
        this._baseURL = this._catalogBaseURL;
        break;
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
