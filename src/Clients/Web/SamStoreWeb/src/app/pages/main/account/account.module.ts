import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from "ngx-mask";
import { AccountService } from "./../../../services/account.service";
import { MaterialModule } from "./../../../material.module";
import { HttpClientModule } from "@angular/common/http";
import { AuthenticationService } from "../../../services/authentication.service";
import { AccountRoutingModule } from "./account-routing.module";
import { RegisterComponent } from "./register/register.component";
import { RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LoginComponent } from "./login/login.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AccountComponent } from "./account/account.component";

@NgModule({
  declarations: [LoginComponent, RegisterComponent, AccountComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxMaskDirective,
    NgxMaskPipe,
    MaterialModule,
  ],
  providers: [AuthenticationService, AccountService, provideNgxMask()],
})
export class AccountModule {}
