import { ProductDTO } from "./../../../models/Products/product.DTO";
import { Component, Input } from "@angular/core";

@Component({
    selector: "app-shopping-product-card",
    templateUrl: "./shopping-product-card.component.html",
    styleUrls: ["./shopping-product-card.component.scss"],
})
export class ShoppingProductCardComponent {
    @Input() product?: ProductDTO;
}
