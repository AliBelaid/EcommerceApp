import { IProduct } from './models/product';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'SKiNet';


  constructor(private basketServices:BasketService,private accountService:AccountService) {


  }
  ngOnInit(): void {
    this.loadBasket();
    this.loadUser();


  }




loadBasket(){
  const basketId = localStorage.getItem('basket_id');

    this.basketServices.GetBasket(basketId).subscribe(()=> {
      console.log('initializes basket');
    },error=>{
      console.log(error);
    });
}
loadUser(){
  const token= localStorage.getItem('token');

    this.accountService.loadCurrentUser(token).subscribe(()=>{

 console.log('loaded user');
    },error=>{
      console.log(error);
    });
  }

}
