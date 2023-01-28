import { ProductDTO } from "./../../../../models/Products/product.DTO";
import { CatalogService } from "./../../../../services/catalog.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-general-catalog",
  templateUrl: "./general-catalog.component.html",
  styleUrls: ["./general-catalog.component.scss"],
})
export class GeneralCatalogComponent implements OnInit {
  products: Array<ProductDTO> = [];

  constructor(private _catalogService: CatalogService) {}

  ngOnInit(): void {
    this._catalogService.getAllProducts().subscribe({
      next: (products) => {
        this.products = products;
        console.log(this.products);
      },
      error: (err) => console.log("ERRO"),
    });
  }
}
