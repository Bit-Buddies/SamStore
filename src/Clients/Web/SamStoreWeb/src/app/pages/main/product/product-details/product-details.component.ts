import { Component, Input, OnInit, OnChanges } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { lastValueFrom } from "rxjs";
import { ProductDTO } from "src/app/models/Products/product.DTO";
import { CatalogControllerService } from "src/app/services/controllers/catalog-controller.service";
import { LoadingService } from "src/app/services/loading.service";
import { ShoppingCartService } from "src/app/services/shopping-cart.service";

@Component({
	selector: "app-product-details",
	templateUrl: "./product-details.component.html",
	styleUrls: ["./product-details.component.scss"],
})
export class ProductDetailsComponent implements OnInit {
	public product?: ProductDTO;
	public productAddedToCart: boolean = false;
	private _productId: string = "";

	constructor(
		private _catalogService: CatalogControllerService,
		private _activatedRoute: ActivatedRoute,
		private _toastrService: ToastrService,
		private _snackbar: MatSnackBar,
		private _shoppingCartService: ShoppingCartService,
		private _router: Router,
		public loadingService: LoadingService
	) {}

	ngOnInit(): void {
		this.getProductDetails();

		this._activatedRoute.params.subscribe((param) => {
			this.getProductDetails();
		});
	}

	private async getProductDetails() {
		this.resetPage();

		this._productId = this._activatedRoute.snapshot.paramMap.get("productId")!;

		if (!this._productId) {
			this._router.navigate(["/home"]);
			return;
		}

		await lastValueFrom(this._catalogService.getById(this._productId))
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

	public async addToCart() {
		await this._shoppingCartService.addOrUpdateItem(this.product!, 1);

		this.productAddedToCart = true;

		this._snackbar.open("Item added to shopping cart", undefined, {
			duration: 2000,
		});
	}

  private resetPage() {
		this._productId = "";
		this.product = undefined;
		this.productAddedToCart = false;
	}
}
