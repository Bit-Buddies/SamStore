import { AccountComponent } from "./account/account.component";
import { RegisterComponent } from "./register/register.component";
import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { LoginComponent } from "./login/login.component";
import { AuthenticationGuard } from "src/app/_guard/authentication.guard";

const routes: Routes = [
    {
        path: "",
        component: AccountComponent,
        children: [
            { path: "login", component: LoginComponent },
            { path: "register", component: RegisterComponent},
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AccountRoutingModule {}
