import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subject, takeUntil } from 'rxjs';
import { ProductDTO } from 'src/app/models/Products/product.DTO';
import { CatalogControllerService } from 'src/app/services/controllers/catalog-controller.service';
import { NavbarService } from 'src/app/services/navbar.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  public productsSellersOfTheWeek: Array<ProductDTO> = new Array<ProductDTO>();
  
  private _unsubscribeAll$: Subject<void> = new Subject<void>();
  
  constructor(
    private _catalogService: CatalogControllerService,
    private _toastrService: ToastrService
    ) { }
  
  ngOnInit(): void {
    this.getSellersOfTheWeek();

    window.onscroll = function() {
      if (window.scrollY > 0 ) {
        document.getElementById("fixed-toolbar")!.style!.opacity = "0";
        document.getElementById("scrolled-toolbar")!.style!.opacity = "100%";
      } else {
        document.getElementById("fixed-toolbar")!.style!.opacity = "100%";
        document.getElementById("scrolled-toolbar")!.style!.opacity = "0";
      }
    }
  }

  public showNavbarOnScroll(){

  }

  public getSellersOfTheWeek(){
    this._catalogService.getAllProducts()
      .pipe(takeUntil(this._unsubscribeAll$))
      .subscribe({
        next: (products: ProductDTO[]) => {
          this.productsSellersOfTheWeek = products;
        },
        error: () => this._toastrService.error("An error has ocourred", undefined)});
  }

  ngOnDestroy(): void {
    this._unsubscribeAll$.next();
    this._unsubscribeAll$.complete();
  }
}

