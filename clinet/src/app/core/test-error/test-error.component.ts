import { HttpClient } from '@angular/common/http';
import { environment } from './../../../environments/environment';
 import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
baseUrl= environment.apiUrl;
validationErrors: any;
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }
get404Error(){
  return this.http.get(this.baseUrl+'Buggy/notfound').subscribe(response=>{
    console.log(response);
  },error=> {   console.log(error);});
}
get400Error(){
  return this.http.get(this.baseUrl+'Buggy/badrequest').subscribe(response=>{
    console.log(response);
  },error=> {   console.log(error);});;
}
get400ValidationError(){
  return this.http.get(this.baseUrl+'products/grhehe').subscribe(response=>{
    console.log(response);
  },error=> {   console.log(error);
    this.validationErrors = error.errors;
  });;
}

get500Error(){
  return this.http.get(this.baseUrl+'Buggy/servererror').subscribe(response=>{
    console.log(response);
  },error=> {   console.log(error);});;
}
}
