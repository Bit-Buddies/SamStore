import { Router } from "@angular/router";
import { AccountService } from "./../../../../services/account.service";
import { GlobalEventsService } from "./../../../../services/events/global-events.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-toolbar",
  templateUrl: "./toolbar.component.html",
  styleUrls: ["./toolbar.component.scss"],
})
export class ToolbarComponent implements OnInit {
  userEmail: string = "";
  logado: boolean = false;
  itensCarrinho: number = 0;

  constructor(private _accountService: AccountService, private _router: Router) {}

  ngOnInit(): void {
    this.validateUserIsLogged();

    GlobalEventsService.userLoggedIn.subscribe(() => {
      this.validateUserIsLogged();
    });
  }

  validateUserIsLogged() {
    const user = this._accountService.getCurrentUser();

    if (user == null) {
      this.logado = false;
      return;
    }

    this.userEmail = user.userToken.email;
    this.logado = true;
  }

  logout() {
    this._accountService.removeCurrentUser();
    location.reload();
  }
}
