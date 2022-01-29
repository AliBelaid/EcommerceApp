  import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { Member } from './../models/member';
@Injectable({
  providedIn: 'root'
})
export class MemberService {
members:Member[] = [];
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http:HttpClient) { }


getMembers():Observable<Member[]>{
if(this.members.length>0 ) return of(this.members);
return  this.http.get<Member[]>(this.baseUrl+'user').pipe(map(members=>
{this.members = members;
  return members;
}));
  }
  getMember(username:string):Observable<Member>{
    const member = this.members.find(x=>x.displayName===username) ;
    if(member !==undefined)  return of(member);
    return this.http.get<Member>(this.baseUrl+'user/'+username);
      }

      updateMember(member:Member) {
        return this.http.put(this.baseUrl+'user' , member).pipe(map(()=> {
          const index =this.members.indexOf(member);
          this.members[index] = member;
        }));
      }

      setMainPhoto(photoId:number) {
        return this.http.put(this.baseUrl +'User/set-main-photo/' +photoId,{});
      }
      deletePhoto(photoId: number) {
         return this.http.delete(this.baseUrl +'User/delete-photo/' +photoId);

      }
    }

