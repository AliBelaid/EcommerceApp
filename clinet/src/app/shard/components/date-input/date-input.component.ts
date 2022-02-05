import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';
import { Component, OnInit, Input, Self } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-date-input',
  templateUrl: './date-input.component.html',
  styleUrls: ['./date-input.component.scss']
})
export class DateInputComponent implements ControlValueAccessor {
  @Input() label :string ;
  @Input() maxDate : Date ;
bsConfig: Partial<BsDatepickerConfig> ;
control: FormControl ;
constructor(@Self() public ngControl: NgControl) {

  this.ngControl.valueAccessor =this;
  this.bsConfig =  {
    containerClass: 'theme-red'
   , dateInputFormat: 'YYYY-MM-DD'
 } ;

 }

onChange(event: any){

}
OnTouched(){}
writeValue(obj: any): void {

  }

registerOnChange(fn: any): void {
 this.onChange =fn;
}
registerOnTouched(fn: any): void {
 this.OnTouched =fn;
}
  setDisabledState?(isDisabled: boolean): void {

  }

}
