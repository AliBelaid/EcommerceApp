import { HttpHandler, HttpHeaders } from '@angular/common/http';
import { IUser } from './../models/user';
import { BehaviorSubject, of, ReplaySubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AsyncValidator } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSources = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSources.asObservable();

  constructor(private http: HttpClient, private route: Router) { }

  login(value: any) {
    return this.http.post<IUser>(this.baseUrl + 'account/login', value).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSources.next(user);
        }
      })
    )
  }

  register(value: any) {
    return this.http.post<IUser>(this.baseUrl + 'account/register', value).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSources.next(user);
         }}))
  }
  checkEmailExists(email: string) {
    return this.http.get(this.baseUrl + 'account/emailexists?email=' + email);
  }

  loadCurrentUser(token: string) {
    if (token == null) {
      this.currentUserSources.next(null);
      return of(null);
    }
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);
    return this.http.get<IUser>(this.baseUrl + 'account', {headers}).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSources.next(user);
        } }))
  }
  logout(){
    this.currentUserSources.next(null);
    localStorage.removeItem('token');
     this.route.navigateByUrl('/account/login');
  }


}
