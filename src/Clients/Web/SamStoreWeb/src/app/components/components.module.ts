import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MaterialModule } from "../material.module";
import { ModalHeaderComponent } from "./main/layout/modal-header/modal-header.component";
import { ShoppingCartCoreComponent } from "./shopping-cart/shopping-cart-core/shopping-cart-core.component";
import { ToolbarComponent } from "./main/layout/toolbar/toolbar.component";
import { RouterModule } from "@angular/router";
import { PageTitleMoreComponent } from "./main/layout/page-title-more/page-title-more.component";

const componentsModules = [ModalHeaderComponent, ShoppingCartCoreComponent, ToolbarComponent, PageTitleMoreComponent];

@NgModule({
  declarations: [...componentsModules],
  exports: [...componentsModules],
  imports: [CommonModule, RouterModule, MaterialModule],
})
export class ComponentsModule {}
