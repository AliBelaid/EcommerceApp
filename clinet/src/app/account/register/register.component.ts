import { AccountService } from './../account.service';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { of, timer } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  maxDate :Date ;
  validationErrors: string[] =[];
  constructor(private accountService: AccountService,
    private fb: FormBuilder, private route: Router) { }

  ngOnInit(): void {
    this.createRegisterForm();
this.maxDate = new Date();
this.maxDate.setFullYear(this.maxDate.getFullYear()-18);
  }


  createRegisterForm() {
    this.registerForm = this.fb.group({
      displayName: [null, [Validators.required]],
      knownAs: [null, [Validators.required]],
      gender: ["male", [Validators.required]],
      dateOfBirth: [null, [Validators.required]],
      country: [null, [Validators.required]],
      city: [null, [Validators.required]],
      introduction: [null, [Validators.required]],
      interests: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.pattern('^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$')],
        [this.validateEmailNotTaken()]],
      password: [null, [Validators.required, this.matchValidator('confirmPassword', true)],],
      confirmPassword: [null, [Validators.required, this.matchValidator('password')]]
    });
  }
  onSubmit() {
    console.log(this.registerForm.value);
    this.accountService.register(this.registerForm.value).subscribe((response) => {
      this.route.navigateByUrl('/shop');
    }, error => {

      this.validationErrors  =error ;
      console.log(error);
    })

  }


  matchValidator(
    matchTo: string,
    reverse?: boolean
  ): ValidatorFn {
    return (control: AbstractControl):
      ValidationErrors | null => {
      if (control.parent && reverse) {
        const c = (control.parent?.controls as any)[matchTo] as AbstractControl;
        if (c) {
          c.updateValueAndValidity();
        }
        return null;
      }
      return !!control.parent &&
        !!control.parent.value &&
        control.value ===
        (control.parent?.controls as any)[matchTo].value
        ? null
        : { matching: true };
    };
  }



  validateEmailNotTaken(): AsyncValidatorFn {
    return control => {
      return timer(500).pipe(
        switchMap(() => {
          if (!control.value) {
            return of(null);
          }
          return this.accountService.checkEmailExists(control.value).pipe(
            map(res => {
              return res ? { emailExists: true } : null;
            })
          )
        })
      )
    }
  }
}
