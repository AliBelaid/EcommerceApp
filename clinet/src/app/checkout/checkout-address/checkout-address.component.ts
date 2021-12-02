import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/account/account.service';
import { FormGroup } from '@angular/forms';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-checkout-address',
  templateUrl: './checkout-address.component.html',
  styleUrls: ['./checkout-address.component.scss']
})
export class CheckoutAddressComponent implements OnInit {
@Input() checkOutForm : FormGroup;
  constructor(private accountService:AccountService ,private toastrService:ToastrService) { }

  ngOnInit(): void {
  }
saveUserAddress(){
this.accountService.updateUserAddress(this.checkOutForm.get('AddressForm').value).subscribe(()=>{
  this.toastrService.success('Address saved');
},
error => {
  this.toastrService.error(error.message);
})
}
}
