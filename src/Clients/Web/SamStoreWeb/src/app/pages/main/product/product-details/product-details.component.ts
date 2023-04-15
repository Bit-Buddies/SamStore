import { Component, Input } from "@angular/core";
import { ProductDTO } from "src/app/models/Products/product.DTO";

@Component({
	selector: "app-product-details",
	templateUrl: "./product-details.component.html",
	styleUrls: ["./product-details.component.scss"],
})
export class ProductDetailsComponent {
	public product?: ProductDTO;
}
