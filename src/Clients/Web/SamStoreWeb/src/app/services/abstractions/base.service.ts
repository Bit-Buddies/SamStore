import { ResponseApiError } from "./../../models/response-api-error";
import { HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { ErrorStateMatcher } from "@angular/material/core";
import { throwError } from "rxjs";

export abstract class BaseApiService {
  protected _baseUrlService: string = "http://localhost:5274/api";

  constructor(protected controllerName: string) {
    this._baseUrlService += `/${controllerName}`;
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
