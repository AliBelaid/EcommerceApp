import { AccountService } from './../account.service';
import { Component, OnInit } from '@angular/core';
import { AsyncValidatorFn, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { of, timer } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
   errors: string[];
  registerForm: FormGroup;
  constructor(private accountService:AccountService,
    private fb: FormBuilder , private route:Router) { }

  ngOnInit(): void {
this.createRegisterForm();

  }

  createRegisterForm(){
    this.registerForm =  this.fb.group({
  displayName : [null, [Validators.required]],
  email:  [null,[Validators.required,Validators.pattern('^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$')],
      [this.validateEmailNotTaken()]],
password: [null,[Validators.required]]
    });
}
onSubmit(){
  console.log(this.registerForm.value);
  this.accountService.register(this.registerForm.value).subscribe((response)=>{
    this.route.navigateByUrl('/shop');
  },error=>{
this.errors = error.errors;
    console.log(error);
  })

}

validateEmailNotTaken() :AsyncValidatorFn{
  return control =>{
    return timer(500).pipe(
              switchMap(()=> {
                if(!control.value) {
                   return of(null);
                }
              return this.accountService.checkEmailExists(control.value).pipe(
                map(res=>{
                  return res?{emailExists: true }: null;
                })
              )
              })
    )
  }
    }
}
