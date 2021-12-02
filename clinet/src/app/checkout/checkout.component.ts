import { AccountService } from 'src/app/account/account.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;
  constructor(private fb: FormBuilder, private accountService: AccountService) { }

  ngOnInit(): void {
    this.createCheckOutForm();
    this.getAddressFormValue();
  }
  createCheckOutForm() {
    this.checkoutForm = this.fb.group(
      {
        AddressForm: this.fb.group({
          firstName: [null, Validators.required],
          lastName: [null, Validators.required],
          zipCode: [null, Validators.required],
          street: [null, Validators.required],
          city: [null, Validators.required],
          state: [null, Validators.required],
        }),
        deliveryForm: this.fb.group({
          deliveryMethod: [null, Validators.required]
        }),
        PaymentForm: this.fb.group({
          nameOnCard: [null, Validators.required],
        }),
      }
    );
  }
  getAddressFormValue() {
    this.accountService.getUserAddress().subscribe((address) => {
      if (address) {
        console.log(address);
        this.checkoutForm.get('AddressForm').patchValue(address);
      }
    }, error => {
      console.log(error);
    })
  }
}
