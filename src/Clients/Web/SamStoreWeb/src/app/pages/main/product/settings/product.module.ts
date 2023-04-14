import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ProductDetailsComponent } from "../product-details/product-details.component";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { NgxMaskDirective, NgxMaskPipe } from "ngx-mask";
import { MaterialModule } from "src/app/material.module";
import { ComponentsModule } from "src/app/components/components.module";
import { AppComponent } from "src/app/app.component";
import { ProductRoutingModule } from "./product-routing.module";
import { ProductComponent } from "./product.component";

@NgModule({
    declarations: [ProductDetailsComponent, ProductComponent],
    imports: [
        CommonModule,
        ProductRoutingModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        NgxMaskDirective,
        NgxMaskPipe,
        MaterialModule,
        ComponentsModule,
    ]
})
export class ProductModule {}
