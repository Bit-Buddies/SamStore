import { ToastrService } from "ngx-toastr";
import { ProductDTO } from "./../../../../models/Products/product.DTO";
import { CatalogControllerService } from "../../../../services/controllers/catalog-controller.service";
import { Component, OnInit } from "@angular/core";
import { IBaseComponent } from "src/app/interfaces/base-component.interface";
import { Subject, takeUntil } from "rxjs";
import { fadeAnimation, staggerAnimation } from "src/app/utils/animation-collection";

@Component({
  selector: "app-general-catalog",
  templateUrl: "./general-catalog.component.html",
  styleUrls: ["./general-catalog.component.scss"],
  animations: [ staggerAnimation("45ms"), fadeAnimation("1000ms cubic-bezier(0.77,0,0.18,1)")]
})
export class GeneralCatalogComponent implements OnInit, IBaseComponent {
  public products: Array<ProductDTO> = [];
  public unsubscribeAll$: Subject<void> = new Subject();

  constructor(private _catalogService: CatalogControllerService, private _toastrService: ToastrService) {}

  ngOnDestroy(): void {
    this.unsubscribeAll$.next();
    this.unsubscribeAll$.complete();
  }

  ngOnInit(): void {
    this._catalogService.getAllProducts()
      .pipe(takeUntil(this.unsubscribeAll$))
      .subscribe({
        next: (products: ProductDTO[]) => {
          this.products = products;
        },
        error: () => this._toastrService.error("An error has ocourred", undefined)});
    }

  public onMoreButtonPressed() {}
}
