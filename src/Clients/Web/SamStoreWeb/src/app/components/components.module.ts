import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material.module';
import { ModalHeaderComponent } from './main/modal-header/modal-header.component';
import { ShoppingCartCoreComponent } from './shopping-cart/shopping-cart-core/shopping-cart-core.component';
import { ToolbarComponent } from './main/layout/toolbar/toolbar.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ModalHeaderComponent, ShoppingCartCoreComponent, ToolbarComponent],
  exports: [ModalHeaderComponent, ShoppingCartCoreComponent, ToolbarComponent],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule
  ]
})
export class ComponentsModule { }
