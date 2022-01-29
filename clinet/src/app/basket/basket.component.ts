import { IBasketItem, IBasketTotal } from './../models/basket';
import { BasketService } from './basket.service';
import { Component, OnInit } from '@angular/core';
import { IBasket } from '../models/basket';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  basket$:  Observable<IBasket | null>;
  basketTotal$ :Observable<IBasketTotal>;
  constructor(private basketServices:BasketService) { }

  ngOnInit() {
    this.basket$ =this.basketServices.basket$;
    this.basketTotal$ =this.basketServices.basketTotal$;
  }

removeBasketItem(item:IBasketItem){
  this.basketServices.removeItemBasket(item);
}
incrementsItemQuantity(item:IBasketItem){
this.basketServices.incrementItemQuantity(item);
}
decrementItemQuantity(item:IBasketItem){
  if(item.quantity>0) {
    this.basketServices.decrementItemQuantity(item);

  }
  }
}
