import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { CatalogControllerService } from "./services/controllers/catalog-controller.service";
import { AccountService } from "./services/account.service";
import { MaterialModule } from "./material.module";
import { AppRoutingModule } from "./app-routing.module";
import { NgModule, LOCALE_ID } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { ToolbarComponent } from "./components/main/layout/toolbar/toolbar.component";

import { FlexLayoutModule } from "@angular/flex-layout";
import { HomeComponent } from "./pages/main/home/home.component";
import { NotfoundComponent } from "./pages/notfound/notfound.component";
import { ToastrModule } from "ngx-toastr";
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from "ngx-mask";
import { DialogService } from "./utils/dialog-service";
import { ComponentsModule } from "./components/components.module";
import { ShoppingCartService } from "./services/shopping-cart.service";
import { LoadingInterceptor } from "./services/interceptors/loading.interceptor";
import { ProductDetailsComponent } from "./pages/main/product/product-details/product-details.component";
import ptBr from "@angular/common/locales/pt";
import { registerLocaleData } from "@angular/common";
import { AuthenticationInterceptor } from "./services/interceptors/authentication.interceptor";
import { ProductCatalogComponent } from "./pages/main/home/general-catalog/product-catalog.component";

registerLocaleData(ptBr);

@NgModule({
	declarations: [AppComponent, HomeComponent, NotfoundComponent, ProductCatalogComponent],
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
		provideNgxMask(),
		{ provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
		{ provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true },
		{ provide: LOCALE_ID, useValue: "pt" },
	],
	bootstrap: [AppComponent],
})
export class AppModule {}
