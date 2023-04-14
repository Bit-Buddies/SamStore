import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { CatalogControllerService } from "./services/controllers/catalog-controller.service";
import { GeneralCatalogComponent } from "./pages/main/home/general-catalog/general-catalog.component";
import { AccountService } from "./services/account.service";
import { MaterialModule } from "./material.module";
import { AppRoutingModule } from "./app-routing.module";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { ToolbarComponent } from "./components/main/layout/toolbar/toolbar.component";

import { FlexLayoutModule } from "@angular/flex-layout";
import { HomeComponent } from "./pages/main/home/home.component";
import { NotfoundComponent } from "./pages/notfound/notfound.component";
import { ToastrModule } from "ngx-toastr";
import { NgxMaskDirective, NgxMaskPipe } from "ngx-mask";
import { DialogService } from "./utils/dialog-service";
import { ComponentsModule } from "./components/components.module";
import { ShoppingCartService } from "./services/shopping-cart.service";
import { LoadingInterceptor } from "./services/interceptors/loading.interceptor";
import { ProductDetailsComponent } from "./pages/main/product/product-details/product-details.component";

@NgModule({
    declarations: [AppComponent, HomeComponent, NotfoundComponent, GeneralCatalogComponent],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        FlexLayoutModule,
        MaterialModule,
        HttpClientModule,
        NgxMaskDirective,
        NgxMaskPipe,
        ComponentsModule,
        ToastrModule.forRoot(),
    ],
    providers: [
        AccountService,
        CatalogControllerService,
        DialogService,
        ShoppingCartService,
        { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    ],
    bootstrap: [AppComponent],
})
export class AppModule {}
