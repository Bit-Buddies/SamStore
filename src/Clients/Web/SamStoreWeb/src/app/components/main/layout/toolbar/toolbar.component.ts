import { Router } from "@angular/router";
import { AccountService } from "./../../../../services/account.service";
import { AuthService } from "./../../../../services/auth.service";
import { GlobalEventsService } from "./../../../../services/events/global-events.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-toolbar",
  templateUrl: "./toolbar.component.html",
  styleUrls: ["./toolbar.component.scss"],
})
export class ToolbarComponent implements OnInit {
  /**
   *
   */
  constructor(private _accountService: AccountService, private _router: Router) {}

  ngOnInit(): void {
    this.validateUserIsLogged();

    GlobalEventsService.userLoggedIn.subscribe(() => this.validateUserIsLogged());
  }

  validateUserIsLogged() {
    const user = this._accountService.getCurrentUser();

    if (user == null) {
      this.logado = false;
      this._router.navigate(["/account/login"]);
      return;
    }

    this.logado = true;
  }

  public logado: boolean = false;
}
