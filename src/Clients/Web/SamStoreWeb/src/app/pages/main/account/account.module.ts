import { AccountService } from "./../../../services/account.service";
import { MaterialModule } from "./../../../material.module";
import { HttpClientModule } from "@angular/common/http";
import { AuthService } from "./../../../services/auth.service";
import { AccountRoutingModule } from "./account-routing.module";
import { FlexLayoutModule } from "@angular/flex-layout";
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
    FlexLayoutModule,
    AccountRoutingModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MaterialModule,
  ],
  providers: [AuthService, AccountService],
})
export class AccountModule {}
