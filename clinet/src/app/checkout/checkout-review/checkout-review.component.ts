import { Basket, IBasket } from './../../models/basket';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { Component, OnInit } from '@angular/core';
import { IBasketItem } from 'src/app/models/basket';

@Component({
  selector: 'app-checkout-review',
  templateUrl: './checkout-review.component.html',
  styleUrls: ['./checkout-review.component.scss']
})
export class CheckoutReviewComponent implements OnInit {
  basket$: Observable<IBasket>;
    constructor(private basketService:BasketService) { }

  ngOnInit(): void {
    this.basket$=this.basketService.basket$;

  }

}
