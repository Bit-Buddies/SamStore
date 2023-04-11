import { Router } from "@angular/router";
import { AccountService } from "./../../../../services/account.service";
import { GlobalEventsService } from "./../../../../services/events/global-events.service";
import { Component, OnInit } from "@angular/core";
import { DialogService } from "src/app/utils/dialog-service";
import { HomeComponent } from "src/app/pages/main/home/home.component";
import { GeneralCatalogComponent } from "src/app/pages/main/home/general-catalog/general-catalog.component";
import { ShoppingCartCoreComponent } from "src/app/components/shopping-cart/shopping-cart-core/shopping-cart-core.component";

@Component({
  selector: "app-toolbar",
  templateUrl: "./toolbar.component.html",
  styleUrls: ["./toolbar.component.scss"],
})
export class ToolbarComponent implements OnInit {
  userEmail: string = "";
  logado: boolean = false;
  cartItemsQuantity: number = 0;

  constructor(
    private _accountService: AccountService,
    private _router: Router,
    private _dialogService: DialogService) {}

  public ngOnInit(): void {
    this.validateUserIsLogged();

    GlobalEventsService.userLoggedIn.subscribe(() => {
      this.validateUserIsLogged();
    });
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
    this._dialogService.genericDialog(ShoppingCartCoreComponent, {width: "70%", autoFocus: false });
  }
}
