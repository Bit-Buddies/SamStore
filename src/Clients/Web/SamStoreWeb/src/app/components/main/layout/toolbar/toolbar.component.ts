import { Router } from "@angular/router";
import { AccountService } from "./../../../../services/account.service";
import { GlobalEventsService } from "./../../../../services/events/global-events.service";
import { Component, OnInit, Input } from "@angular/core";
import { DialogService } from "src/app/utils/dialog-service";
import { HomeComponent } from "src/app/pages/main/home/home.component";
import { GeneralCatalogComponent } from "src/app/pages/main/home/general-catalog/general-catalog.component";
import { ShoppingCartCoreComponent } from "src/app/components/shopping/shopping-cart-core/shopping-cart-core.component";
import { ShoppingCartService } from "src/app/services/shopping-cart.service";
import { LoadingService } from "src/app/services/loading.service";
import { NavbarService } from "src/app/services/navbar.service";
import { BehaviorSubject, Subject, Subscription } from "rxjs";

@Component({
	selector: "app-toolbar",
	templateUrl: "./toolbar.component.html",
	styleUrls: ["./toolbar.component.scss"],
})
export class ToolbarComponent implements OnInit {
	@Input() public validateShowNavbar: boolean = false; 

	public userEmail: string = "";
	public logado: boolean = false;
	public showNavbar: boolean = true;

	constructor(
		private _router: Router,
		private _globalEventService: GlobalEventsService,
		private _accountService: AccountService,
		private _dialogService: DialogService,
		public loadingService: LoadingService,
		public shoppingCartService: ShoppingCartService,
		public navbarService: NavbarService
	) { 
		this.navbarService.showNavbar$.subscribe(show => this.showNavbar = show);	
	}

	public ngOnInit(): void {
		this.validateUserIsLogged();

		this.shoppingCartService.init();

		this._globalEventService.userLoggedIn.subscribe(() => {
			this.validateUserIsLogged();
			this.shoppingCartService.init();
		});
	}

	private validateUserIsLogged() {
		this.logado = this._accountService.isLogged();
	}

	public logout() {
		this._accountService.removeCurrentUser();
		location.reload();
	}

	public calculateTotalQuantityItems(): string {
		if (!this.shoppingCartService.shoppingCart?.items?.length) return "0";

		return this.shoppingCartService
			.shoppingCart!.items.reduce((total, item) => (total += item.quantity), 0)
			.toFixed();
	}
}
