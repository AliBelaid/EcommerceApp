import { BasketService } from './../../../basket/basket.service';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { IBasketTotal } from 'src/app/models/basket';

@Component({
  selector: 'app-order-total',
  templateUrl: './order-total.component.html',
  styleUrls: ['./order-total.component.scss']
})
export class OrderTotalComponent implements OnInit {
basketTotal$: Observable<IBasketTotal| null>;
  constructor(private basketServices:BasketService) { }

  ngOnInit(): void {
    this.basketTotal$ = this.basketServices.basketTotal$;
  }

}
