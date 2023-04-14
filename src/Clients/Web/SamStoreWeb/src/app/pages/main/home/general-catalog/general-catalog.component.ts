import { ToastrService } from "ngx-toastr";
import { ProductDTO } from "./../../../../models/Products/product.DTO";
import { CatalogControllerService } from "../../../../services/controllers/catalog-controller.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-general-catalog",
  templateUrl: "./general-catalog.component.html",
  styleUrls: ["./general-catalog.component.scss"],
})
export class GeneralCatalogComponent implements OnInit {
  products: Array<ProductDTO> = [];

  constructor(private _catalogService: CatalogControllerService, private _toastrService: ToastrService) {}

  ngOnInit(): void {
    this._catalogService.getAllProducts().subscribe({
      next: (products: ProductDTO[]) => {
        this.products = products;
      },
      error: () => this._toastrService.error("An error has ocourred", undefined),
    });
  }

  public onMoreButtonPressed() {}
}
