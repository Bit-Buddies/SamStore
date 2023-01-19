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

@NgModule({
  declarations: [AppComponent, ToolbarComponent, HomeComponent, NotfoundComponent],
  imports: [BrowserModule, BrowserAnimationsModule, AppRoutingModule, FlexLayoutModule, MaterialModule],
  providers: [AccountService],
  bootstrap: [AppComponent],
})
export class AppModule {}
