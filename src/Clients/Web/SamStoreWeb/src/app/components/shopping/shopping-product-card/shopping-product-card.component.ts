import { AccountService } from "src/app/services/account.service";
import { ProductDTO } from "./../../../models/Products/product.DTO";
import { Component, Input } from "@angular/core";
import { ToastrService } from "ngx-toastr";

@Component({
    selector: "app-shopping-product-card",
    templateUrl: "./shopping-product-card.component.html",
    styleUrls: ["./shopping-product-card.component.scss"],
})
export class ShoppingProductCardComponent {
    @Input() public product?: ProductDTO;
    public isFavorite: boolean = false;

    constructor(private _accountService: AccountService, private _toastrService: ToastrService) {}

    public favoriteProduct() {
        if (!this._accountService.isLogged()) {
            this._accountService.callLoginModal().subscribe({
                next: (success) => {
                    if (success) {
                        this.isFavorite = !this.isFavorite;

                        this.showFavoriteToastrMessage;
                    }
                },
            });

            return;
        } else {
            this.isFavorite = !this.isFavorite;
        }

        if (this.isFavorite) this.showFavoriteToastrMessage();
    }

    private showFavoriteToastrMessage(){
      this._toastrService.success(`product ${this.product?.name} was favorited`, undefined, {
        positionClass: 'toast-bottom-center',
        timeOut: 2000
      });
    }
}
