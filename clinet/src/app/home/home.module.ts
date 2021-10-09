import { ShardModule } from './../shard/shard.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    ShardModule
  ],exports:[HomeComponent]
})
export class HomeModule { }
