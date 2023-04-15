import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { lastValueFrom } from "rxjs";
import { ProductDTO } from "src/app/models/Products/product.DTO";
import { CatalogControllerService } from "src/app/services/controllers/catalog-controller.service";

@Component({
	selector: "app-product-details",
	templateUrl: "./product-details.component.html",
	styleUrls: ["./product-details.component.scss"],
})
export class ProductDetailsComponent implements OnInit {
	public product?: ProductDTO;

	constructor(
		private _catalogService: CatalogControllerService,
		private _activatedRoute: ActivatedRoute,
		private _toastrService: ToastrService,
		private _router: Router
	) {}

	ngOnInit(): void {
		const productId = this._activatedRoute.snapshot.paramMap.get("productId");

		if (!productId) {
			this._router.navigate(["/home"]);
			return;
		}

		lastValueFrom(this._catalogService.getById(productId))
			.then((product: ProductDTO) => (this.product = product))
			.catch((err) => {
				if (!!err.errors)
					err.errors.Mensagens.forEach((er: string) => {
						this._toastrService.error(er, undefined, {
							positionClass: "toast-bottom-right",
						});
					});
				else
					this._toastrService.error("An error has ocourred", undefined, {
						positionClass: "toast-bottom-right",
					});

				this._router.navigate(["/home"]);
			});
	}
}
