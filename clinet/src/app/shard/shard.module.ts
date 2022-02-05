import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { OrderTotalComponent } from './components/order-total/order-total.component';
import { ReactiveFormsModule } from '@angular/forms';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { TextInputComponent } from './components/text-input/text-input.component';
import { CdkStep, CdkStepperModule} from '@angular/cdk/stepper';
import { StepperComponent } from './components/stepper/stepper.component';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';
import { FileUploadModule } from 'ng2-file-upload';
import { DateInputComponent } from './components/date-input/date-input.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { TimeagoModule } from 'ngx-timeago';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalComponent,
    TextInputComponent,
    StepperComponent,
    BasketSummaryComponent,
    DateInputComponent,

  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    CdkStepperModule,
    RouterModule,
    FileUploadModule,
    BsDatepickerModule.forRoot(),
    ButtonsModule,
    TimeagoModule.forRoot()
  ], exports: [

    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    CarouselModule,
    OrderTotalComponent,
    ReactiveFormsModule,
    BsDropdownModule
  ,TextInputComponent
,StepperComponent,
BasketSummaryComponent
,FileUploadModule,
CdkStep,
CdkStepperModule,
BsDatepickerModule,
DateInputComponent,
ButtonsModule ,
TimeagoModule]
})
export class ShardModule { }
