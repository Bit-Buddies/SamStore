import { NotfoundComponent } from "./pages/notfound/notfound.component";
import { HomeComponent } from "./pages/main/home/home.component";
import { AppComponent } from "./app.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { hideNavbarGuard, showNavbarGuard } from "./_guard/hide-navbar.guard";

const routes: Routes = [
    { path: "", redirectTo: "home", pathMatch: "full" },
    { 
        path: "home", 
        component: HomeComponent, 
        canActivate: [hideNavbarGuard], 
        canDeactivate: [showNavbarGuard],
        title: "SamStore - Home"},
    {
        path: "product",
        title: "SamStore - Product",
        canActivate: [],
        loadChildren: () => import("./pages/main/product/settings/product.module").then((m) => m.ProductModule),
    },
    {
        path: "account",
        title: "SamStore - Account",
        loadChildren: () => import("./pages/main/account/settings/account.module").then((m) => m.AccountModule),
    },
    { path: "**", component: NotfoundComponent, title: "Ops! Not Found" },
];

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forRoot(routes, {
            useHash: false,
        }),
    ],
    exports: [RouterModule],
})
export class AppRoutingModule {}
