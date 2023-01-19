import { HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { throwError } from "rxjs";

export abstract class BaseService {
  protected _baseUrlService: string = "http://localhost:5274/api";

  /**
   *
   */
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

  protected extractErrors(response: Response | any) {
    let customErrors: Array<string> = [];

    if (response instanceof HttpErrorResponse) {
      if (response.statusText == "Unknown Error") {
        customErrors.push("Ocorreu um erro desconhecido");
        response.error.errors = customErrors;
      }
    }

    console.error(response);
    return throwError(() => response);
  }
}
