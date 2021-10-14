import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/models/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  basket$:  Observable<IBasket | null>;
  constructor(private basketServices:BasketService) { }

  ngOnInit() {
    this.basket$ =this.basketServices.basket$;
  }

}
