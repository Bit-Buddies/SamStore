import { Router } from "@angular/router";
import { GlobalEventsService } from "./../../../../services/events/global-events.service";
import { LoginData } from "./../../../../models/login-data";
import { AccountService } from "./../../../../services/account.service";
import { AuthenticationControllerService } from "../../../../services/controllers/authentication-controller.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Component } from "@angular/core";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent { }
