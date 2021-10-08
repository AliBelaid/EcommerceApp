import { ShopService } from './../shop.service';
import { IProduct } from './../../models/product';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  constructor(private shopServices:ShopService,
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.loadProduct();
  }
loadProduct(){
  const id = this.activeRoute.snapshot.paramMap.get('id')
  this.shopServices.getProduct(Number(id)).subscribe(product=>{
    this.product= product
  },error=> {
    console.log(error);
  });
}
}
