import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from "ngx-mask";
import { AccountService } from "../../../../services/account.service";
import { MaterialModule } from "../../../../material.module";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { AuthenticationControllerService } from "../../../../services/controllers/authentication-controller.service";
import { AccountRoutingModule } from "./account-routing.module";
import { RegisterComponent } from "../register/register.component";
import { RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LoginComponent } from "../login/login.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AccountComponent } from "./account.component";
import { ComponentsModule } from "src/app/components/components.module";
import { LoadingInterceptor } from "src/app/services/interceptors/loading.interceptor";

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
        ComponentsModule,
    ],
    providers: [
        AuthenticationControllerService,
        provideNgxMask(),
    ],
})
export class AccountModule {}
