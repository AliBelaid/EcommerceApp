import { AccountService } from './../account.service';
import { Component, OnInit } from '@angular/core';
import { EmailValidator, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginFrom:FormGroup;
  returnUrl:string;
  constructor(private accountService: AccountService,
    private activatedRoute:ActivatedRoute ,private route:Router) { }

  ngOnInit(): void {
    this.returnUrl = this.activatedRoute.snapshot.queryParams.returnUrl || '/shop';
    this.createLoginForm();
  }
  createLoginForm(){
    this.loginFrom = new FormGroup({
email:  new FormControl('',[Validators.required,Validators.pattern('^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$')]),
password: new FormControl('',[Validators.required])


    });
  }
onSubmit(){
  console.log(this.loginFrom.value);
  this.accountService.login(this.loginFrom.value).subscribe(()=>{
   this.route.navigateByUrl(this.returnUrl);

  },error=> {
    console.log(error);

  })
}
}
