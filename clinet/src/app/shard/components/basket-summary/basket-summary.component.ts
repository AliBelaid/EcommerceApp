import { IOrder, IOrderItem } from './../../../models/order';
import { IBasketItem } from './../../../models/basket';
import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';


@Component({
  selector: 'app-basket-summary',
  templateUrl: './basket-summary.component.html',
  styleUrls: ['./basket-summary.component.scss']
})
export class BasketSummaryComponent implements OnInit {
 //  basket$:Observable<IBasket>;
   @Output() decrement: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
   @Output() increment: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
   @Output() remove: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
   @Input() items : (IBasketItem[] |  IOrderItem[] | any[]) =[];
   @Input() isBasket= true;
   @Input() isOrder= false;

  constructor() { }

  ngOnInit(): void {
   // this.basket$= this.basketService.basket$;
  }
  decrementItemQuantity(item:IBasketItem) {
    this.decrement.emit(item);
  }
  incrementsItemQuantity(item:IBasketItem) {
    this.increment.emit(item);
  }
  removeBasketItem(item:IBasketItem) {
    this.remove.emit(item);
  }
}
