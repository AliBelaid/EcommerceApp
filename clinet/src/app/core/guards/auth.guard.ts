import { map } from 'rxjs/operators';
import { IUser } from 'src/app/models/user';
import { AccountService } from './../../account/account.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

constructor(private accountService:AccountService
          ,private route:Router) {


}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(auth => {
        if(auth) {
          return true ;
        }
        this.route.navigate(['account/login'],{queryParams: {
          returnUrl:state.url }});
          return false ;
      })
    );
  }

}
