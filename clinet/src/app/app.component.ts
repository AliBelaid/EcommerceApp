import { IProduct } from './models/product';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './models/pagination';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'SKiNet';


  constructor(private basketServices:BasketService) {


  }
  ngOnInit(): void {

  const basketId = localStorage.getItem('basket_id');
  if(basketId) {
    this.basketServices.GetBasket(basketId).subscribe(()=> {
      console.log('initializes basket');
    },error=>{
      console.log(error);
    });
  }


  }


}
