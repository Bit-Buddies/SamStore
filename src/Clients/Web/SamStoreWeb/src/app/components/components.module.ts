import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MaterialModule } from "../material.module";
import { ModalHeaderComponent } from "./main/layout/modal-header/modal-header.component";
import { ShoppingCartCoreComponent } from "./shopping/shopping-cart-core/shopping-cart-core.component";
import { ToolbarComponent } from "./main/layout/toolbar/toolbar.component";
import { RouterModule } from "@angular/router";
import { PageTitleMoreComponent } from "./main/layout/page-title-more/page-title-more.component";
import { ShoppingProductCardComponent } from "./shopping/shopping-product-card/shopping-product-card.component";
import { ShoppingProductRatingComponent } from "./shopping/shopping-product-rating/shopping-product-rating.component";
import { LoginCoreComponent } from "./authentication/login-core/login-core.component";
import { RegisterCoreComponent } from "./authentication/register-core/register-core.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { LoginModalComponent } from './authentication/login-modal/login-modal.component';

const componentsModules = [
    ModalHeaderComponent,
    ShoppingCartCoreComponent,
    ToolbarComponent,
    PageTitleMoreComponent,
    ShoppingProductCardComponent,
    ShoppingProductRatingComponent,
    LoginCoreComponent,
    RegisterCoreComponent,
];

@NgModule({
    declarations: [...componentsModules, LoginModalComponent],
    exports: [...componentsModules],
    imports: [CommonModule, RouterModule, MaterialModule, FormsModule, ReactiveFormsModule],
})
export class ComponentsModule {}
