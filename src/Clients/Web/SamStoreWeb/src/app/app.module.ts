import { HttpClientModule } from "@angular/common/http";
import { CatalogService } from "./services/catalog.service";
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
import { NotfoundComponent } from "./pages/main/notfound/notfound.component";
import { ToastrModule } from "ngx-toastr";
import { NgxMaskDirective, NgxMaskPipe } from "ngx-mask";

@NgModule({
  declarations: [AppComponent, ToolbarComponent, HomeComponent, NotfoundComponent, GeneralCatalogComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FlexLayoutModule,
    MaterialModule,
    HttpClientModule,
    NgxMaskDirective,
    NgxMaskPipe,
    ToastrModule.forRoot(),
  ],
  providers: [AccountService, CatalogService],
  bootstrap: [AppComponent],
})
export class AppModule {}
