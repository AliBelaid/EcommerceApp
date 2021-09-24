import { ShardModule } from './shard/shard.module';
import { CoreModule } from './core/core.module';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarComponent } from './core/nav-bar/nav-bar.component';
import { ShopModule } from './shop/shop.module';
import { ShopService } from './shop/shop.service';

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
    ShopModule,

  ],
  providers: [

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
