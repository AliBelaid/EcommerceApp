import { LoadingInterceptor } from './core/interceptors/loading.interceptors';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { HomeModule } from './home/home.module';
import { CoreModule } from './core/core.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbCarouselModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import {CarouselModule}  from 'ngx-bootstrap/carousel';
@NgModule({
  declarations: [
    AppComponent,

  ],
  imports: [
    CoreModule,
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgxSpinnerModule,
    HomeModule,


  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass: ErrorInterceptor,multi:true}
,{provide:HTTP_INTERCEPTORS,useClass: LoadingInterceptor,multi:true}
  ],
  bootstrap: [AppComponent],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
]
})
export class AppModule { }
