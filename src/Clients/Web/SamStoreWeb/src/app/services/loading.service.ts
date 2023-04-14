import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  private _isLoading: boolean = false;

  public setLoading(isLoading: boolean) {
    this._isLoading = isLoading;
  }

  public getLoading(): boolean {
    return this._isLoading;
  }
}
