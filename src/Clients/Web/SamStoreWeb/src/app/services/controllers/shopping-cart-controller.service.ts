import { Injectable } from '@angular/core';
import { ApiServiceEnum, BaseApiService } from '../abstractions/base.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartControllerService extends BaseApiService {
  constructor(private _httpClient: HttpClient) {
    super("ShoppingCart", ApiServiceEnum.ShoppingCart);
  }
}
