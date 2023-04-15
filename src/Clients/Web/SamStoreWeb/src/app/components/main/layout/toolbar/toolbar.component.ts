import { Router } from "@angular/router";
import { AccountService } from "./../../../../services/account.service";
import { GlobalEventsService } from "./../../../../services/events/global-events.service";
import { Component, OnInit } from "@angular/core";
import { DialogService } from "src/app/utils/dialog-service";
import { HomeComponent } from "src/app/pages/main/home/home.component";
import { GeneralCatalogComponent } from "src/app/pages/main/home/general-catalog/general-catalog.component";
import { ShoppingCartCoreComponent } from "src/app/components/shopping/shopping-cart-core/shopping-cart-core.component";
import { ShoppingCartService } from "src/app/services/shopping-cart.service";

@Component({
	selector: "app-toolbar",
	templateUrl: "./toolbar.component.html",
	styleUrls: ["./toolbar.component.scss"],
})
export class ToolbarComponent implements OnInit {
	userEmail: string = "";
	logado: boolean = false;

	constructor(
		private _router: Router,
		private _globalEventService: GlobalEventsService,
		private _accountService: AccountService,
		private _dialogService: DialogService,
		public shoppingCartService: ShoppingCartService
	) {}

	public ngOnInit(): void {
		this.validateUserIsLogged();

		this._globalEventService.userLoggedIn.subscribe(() => {
			this.validateUserIsLogged();
			this.shoppingCartService.init();
		});

		this.shoppingCartService.init();
	}

	private validateUserIsLogged() {
		const user = this._accountService.getCurrentUser();

		if (user == null) {
			this.logado = false;
			return;
		}

		this.userEmail = user.userToken.email;
		this.logado = true;
	}

	public logout() {
		this._accountService.removeCurrentUser();
		location.reload();
	}

	public openShoppingCartModal() {
		this._dialogService.genericDialog(ShoppingCartCoreComponent, { width: "70%", autoFocus: false });
	}

	public calculateTotalQuantityItems(): string {
		if (!this.shoppingCartService.shoppingCart?.items?.length) return "0";

		return this.shoppingCartService
			.shoppingCart!.items.reduce((total, item) => (total += item.quantity), 0)
			.toFixed();
	}
}
