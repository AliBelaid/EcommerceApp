import { ShopParams } from './../models/ShopParams';
import { IBrand } from './../models/brand';
import { ShopService } from './shop.service';
import { IProduct } from './../models/product';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IType } from '../models/productType';
import { isThisTypeNode } from 'typescript';



@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products!: IProduct[];
  @ViewChild('search', { static: false })
  searchTerm!: ElementRef;
  brands!: IBrand[];
  types!: IType[];
  totalCount = 0;
  shopParams = new ShopParams();

  sortOptions = [
    { 'name': 'Alphabetical', value: 'name' },
    { 'name': 'Price : Low to Hight', value: 'priceAsc' },
    { 'name': 'Price : Hight to Low', value: 'priceDesc' },


  ];
  constructor(private shopServices: ShopService) { }

  ngOnInit(): void {
    this.getBrand();
    this.getProducts();
    this.getType();

  }

  getProducts() {
    this.shopServices.getProducts(this.shopParams).subscribe((response) => {
      this.products = response!.data;
      this.shopParams.pageSize = response!.pageSize;
      this.shopParams.pageNumber = response!.pageIndex;
      this.totalCount = response!.count;
    },
      error => {
        console.log(error);
      }
    );
  }
  getBrand() {
    this.shopServices.getBrand().subscribe((response) => {
      this.brands = [{ id: 0, name: 'All' }, ...response];
    },
      error => {
        console.log(error);
      }
    );
  }
  getType() {
    this.shopServices.getType().subscribe((response) => {
      this.types = [{ id: 0, name: 'All' }, ...response];
    },
      error => {
        console.log(error);
      }
    );
  }
  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber=1;

    this.getProducts();
  }
  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber=1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    console.log(sort);
    this.shopParams.sort = sort;
    this.getProducts();

  }
  pageChanged(event: any) {
    if(this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }

  }
  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.getProducts();
  }
  onRest() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
