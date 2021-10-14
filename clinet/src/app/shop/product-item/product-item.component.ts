import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
  @Input()  product!: IProduct;
  constructor(private basketServices:BasketService) { }

  ngOnInit(): void {
  }
addItemToBasket(){
  this.basketServices.addItemsBasket(this.product);
}
}
