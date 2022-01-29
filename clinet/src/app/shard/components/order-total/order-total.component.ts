import { BasketService } from './../../../basket/basket.service';
import { Observable } from 'rxjs';
import { Component, Input, OnInit } from '@angular/core';
import { IBasketTotal } from 'src/app/models/basket';

@Component({
  selector: 'app-order-total',
  templateUrl: './order-total.component.html',
  styleUrls: ['./order-total.component.scss']
})
export class OrderTotalComponent implements OnInit {

@Input()   shipping: number;
@Input()   subTotal: number;
@Input()   total: number;
  constructor() { }

  ngOnInit(): void {

  }

}
