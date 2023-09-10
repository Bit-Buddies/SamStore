
import { AfterViewInit, Component, ElementRef, OnChanges, QueryList, Renderer2, SimpleChanges, ViewChild, ViewChildren } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Subject, takeUntil } from "rxjs";
import { IBaseComponent } from "src/app/interfaces/base-component.interface";
import { ShoppingCartItemDTO } from "src/app/models/ShoppingCarts/shopping-cart-item.DTO";
import { AccountService } from "src/app/services/account.service";
import { ShoppingCartService } from "src/app/services/shopping-cart.service";
import { fadeAnimation, staggerAnimation } from "src/app/utils/animation-collection";
import { DialogService } from "src/app/utils/dialog-service";
import { ModalDialogComponent } from "src/app/utils/modal-dialog";

@Component({
	selector: "app-shopping-cart-core",
	templateUrl: "./shopping-cart-core.component.html",
	styleUrls: ["./shopping-cart-core.component.scss"],
	animations: [ 
		staggerAnimation("50ms"), 
		fadeAnimation("100ms cubic-bezier(0.79,0.14,0.15,0.86)")]
})
export class ShoppingCartCoreComponent extends ModalDialogComponent implements IBaseComponent {
	@ViewChild("modalContainer") modalContainerRef? : ElementRef;
	@ViewChildren("tableRow") tableRows?: QueryList<ElementRef>;

	public displayedColumns = ["image", "details", "price", "total", "actions"];
	public loginAlert: boolean = false;
	public unsubscribeAll$: Subject<void> = new Subject()

	constructor(
		private _accountService: AccountService,
		private _toastrService: ToastrService,
		private _dialogService: DialogService,
		private _renderer: Renderer2,
		private _router: Router,
		public shoppingCartService: ShoppingCartService,
		public dialogRef: MatDialogRef<ShoppingCartCoreComponent>,
	) {
		super();
	}
	
	ngOnDestroy(): void {
		this.unsubscribeAll$.next();
		this.unsubscribeAll$.complete();
	}

	public onClickContinueButton() {
		this.dialogRef.close();
	}

	public onClickRemoveItem(item: ShoppingCartItemDTO) {
		this.shoppingCartService.removeItem(item.productId);
	}

	public checkout() {
		console.log(this.modalContainerRef);
		console.log(this.tableRows)

		if (!this._accountService.isLogged()) {
			this._accountService.callLogin()
				.pipe(takeUntil(this.unsubscribeAll$))
				.subscribe({
					next: (success: boolean) => {
						if (success) {
							//TODO REDIRECT TO PURCHASE PAGE
						} else {
							this.loginAlert = true;
						}
					}});

			return;
		}

		//TODO REDIRECT TO PURCHASE PAGE
	}

	public redirectToProductDetails(productId: string) {
		this.dialogRef.afterClosed()
			.pipe(takeUntil(this.unsubscribeAll$))
			.subscribe(() => {
				this._router.navigate([`/product/details/${productId}`]);
			});

		this.dialogRef.close();
	}
}
