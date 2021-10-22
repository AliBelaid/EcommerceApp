import { AccountService } from './../../account/account.service';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/models/basket';
import { IUser } from 'src/app/models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  basket$:  Observable<IBasket>;
  currentUser$:Observable<IUser>;
  constructor(private basketServices:BasketService,private accountService:AccountService) { }

  ngOnInit() {
    this.basket$ =this.basketServices.basket$;
this.currentUser$ = this.accountService.currentUser$;
  }
logout(){
this.accountService.logout();
}
}
