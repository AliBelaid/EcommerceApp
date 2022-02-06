import { IUser } from 'src/app/models/user';
import { UserParams } from './../models/userParam';
import { PaginationResult } from './../models/paginationMember';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { Member } from './../models/member';
import { AccountService } from '../account/account.service';
@Injectable({
  providedIn: 'root'
})
export class MemberService {
  members: Member[] = [];
  memberCache = new Map();
  baseUrl = 'https://localhost:5001/api/';
  user: IUser;
  userParams: UserParams;
  constructor(private http: HttpClient, private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe((resp) => {
      this.user = resp;
      this.userParams = new UserParams(resp);
      //  this.loadMembers();
    });

  }
  getUserParams(): UserParams {
    return this.userParams;
  }
  setUserParams(params: UserParams) {
    this.userParams = params;
  }
  resetFilters() {
    this.userParams = new UserParams(this.user);
    return this.userParams;
  }
  getLikes(predicate: string, pageNumber: number, pageSize: number) {
    let params = new HttpParams();
    params = this.getPatinationHeader(pageNumber, pageSize);
    params = params.append('Predicate', predicate);
    // return this.http.get<Partial<Member[]>>(this.baseUrl +'likes?predicate=' + predicate);
    return this.getPaginationResult<Partial<Member[]>>(params, this.baseUrl + 'likes');
  }
  addLike(username: string) {
    return this.http.post(this.baseUrl + 'likes/' + username, {});
  }





  getMembers(userParams: UserParams) {

    var response = this.memberCache.get(Object.values(userParams).join('-'));
    if (response) {
      return of(response);
    }
    console.log(Object.values(userParams).join('-'));
    let params = new HttpParams();
    params = this.getPatinationHeader(userParams.pageNumber, userParams.pageSize);

    params = params.append('minAge', userParams.minAge.toString());
    params = params.append('maxAge', userParams.maxAge.toString());
    params = params.append('gender', userParams.gender.toString());
    params = params.append('OrderBy', userParams.orderBy.toString());

    return this.getPaginationResult<Member[]>(params, this.baseUrl + 'user').pipe(
      map((response) => {
        this.memberCache.set(Object.values(userParams).join('-'), response);
        return response;
      }));
  }

  private getPaginationResult<T>(params: HttpParams, url: string) {
    const paginationResult: PaginationResult<T> = new PaginationResult<T>();
    return this.http.get<T>(url, { observe: 'response', params }).pipe(map(response => {
      paginationResult.result = response.body;
      if (response.headers.get('pagination') !== null) {
        paginationResult.pagination = JSON.parse(response.headers.get('pagination'));
      }
      return paginationResult;
    }));
  }

  private getPatinationHeader(pageNumber: number, pageSize: number) {
    let params = new HttpParams();
    params = params.append('PageIndex', pageNumber.toString());
    params = params.append('PageSize', pageSize.toString());

    return params;
  }


  getMember(username: string): Observable<Member> {

    const member = [...this.memberCache.values()].reduce((arr, elem) =>
      arr.concat(elem.result), []).find((member: Member) => member.displayName === username);

    if (member) {
      return of(member);
    }
    console.log(member);
    return this.http.get<Member>(this.baseUrl + 'user/' + username);
  }

  updateMember(member: Member) {
    return this.http.put(this.baseUrl + 'user', member).pipe(map(() => {
      const index = this.members.indexOf(member);
      this.members[index] = member;
    }));
  }

  setMainPhoto(photoId: number) {
    return this.http.put(this.baseUrl + 'User/set-main-photo/' + photoId, {});
  }
  deletePhoto(photoId: number) {
    return this.http.delete(this.baseUrl + 'User/delete-photo/' + photoId);

  }
}

