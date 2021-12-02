import { BasketService } from 'src/app/basket/basket.service';
import { IDelivaryMethod } from './../../models/delivery';
import { CheckoutService } from './../checkout.service';
import { FormGroup } from '@angular/forms';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {
@Input() checkoutForm: FormGroup;
DelivaryMethods : IDelivaryMethod[];
  constructor(private checkoutService:CheckoutService ,private basketService:BasketService) { }

  ngOnInit(): void {
    this.checkoutService.getDelivaryMethods().subscribe((response )=> {
this.DelivaryMethods = response ;

    },error=> {
      console.log(error);
    })
  }

  setShippingPrice(deliveryMethod:IDelivaryMethod) {
    console.log(deliveryMethod);
    this.basketService.setShippingPrice(deliveryMethod);

  }
}
