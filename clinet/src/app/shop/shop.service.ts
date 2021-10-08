import { IProduct } from './../models/product';
import { ShopParams } from './../models/ShopParams';
import { IType } from '../models/productType';
import { IBrand } from './../models/brand';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../models/pagination';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }

  getProducts(ShopParams: ShopParams) {
    let params = new HttpParams();
    if (ShopParams.brandId) {
      params = params.append('brandId', ShopParams.brandId.toString());
    }
    if (ShopParams.typeId) {
      params = params.append('typeId', ShopParams.typeId.toString());
    }
    if (ShopParams.search) {
      params = params.append('search', ShopParams.search);
    }
    params = params.append('sort', ShopParams.sort);
    params = params.append('pageIndex', ShopParams.pageNumber.toString());
    params = params.append('pageSize', ShopParams.pageSize.toString());



    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params }).pipe(
      map(response => {
        return response.body;
      })
    );
  }
  getBrand() {
    return this.http.get<IBrand[]>(this.baseUrl + 'Products/brands');
  }
  getType() {
    return this.http.get<IType[]>(this.baseUrl + 'Products/types');
  }
  getProduct(id:number){
    return this.http.get<IProduct>(this.baseUrl+'Products/'+id);
  }

}
