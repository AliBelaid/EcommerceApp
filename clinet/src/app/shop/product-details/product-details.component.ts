import { BasketService } from 'src/app/basket/basket.service';
import { ShopService } from './../shop.service';
import { IProduct } from './../../models/product';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  quantity=1;
  constructor(private shopServices:ShopService,
    private activeRoute: ActivatedRoute,
    private breadcrumbServices:BreadcrumbService,
    private basketServices: BasketService) {
this.breadcrumbServices.set('@productDetails',' ');

     }

  ngOnInit() {
    this.loadProduct();
  }
loadProduct(){
   this.shopServices.getProduct(Number(this.activeRoute.snapshot.paramMap.get('id'))).subscribe(product=>{
    this.product= product;
    this.breadcrumbServices.set('@productDetails',product.name);

  },error=> {
    console.log(error);
  });
}


addItemToBasket(){

  this.basketServices.addItemsBasket(this.product,this.quantity);
  }

  incrementQuantity(){
this.quantity++;
  }
  decrementQuantity(){
    if(this.quantity>1)
    this.quantity--;
      }
}
