import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { ProductComponent } from "./product.component";
import { ProductDetailsComponent } from "../product-details/product-details.component";
import { NotfoundComponent } from "src/app/pages/notfound/notfound.component";

const routes: Routes = [
	{
		path: "",
		component: ProductComponent,
		children: [
			{
				path: "details/:productId",
				component: ProductDetailsComponent,
			},
		],
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class ProductRoutingModule {}
