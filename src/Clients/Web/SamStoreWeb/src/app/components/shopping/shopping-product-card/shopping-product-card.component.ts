import { AccountService } from "src/app/services/account.service";
import { ProductDTO } from "./../../../models/Products/product.DTO";
import { Component, Input } from "@angular/core";

@Component({
    selector: "app-shopping-product-card",
    templateUrl: "./shopping-product-card.component.html",
    styleUrls: ["./shopping-product-card.component.scss"],
})
export class ShoppingProductCardComponent {
    @Input() public product?: ProductDTO;
    public isFavorite: boolean = false;

    constructor(private _accountService: AccountService) { }

    public favoriteProduct() {
      if(!this._accountService.isLogged()) {
        this._accountService.callLoginModal().subscribe({
          next: (success) => {
            if(success) {
              this.isFavorite = !this.isFavorite;
            }
          }
        })
      }else{
        this.isFavorite = !this.isFavorite;
      }
    }
}
