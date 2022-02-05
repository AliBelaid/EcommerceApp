import { take } from 'rxjs/operators';
import { IUser } from 'src/app/models/user';
import { AccountService } from './../account/account.service';
import { UserParams } from './../models/userParam';
import { PaginationMember } from './../models/paginationMember';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Member } from '../models/member';
import { MemberService } from './member.service';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.scss']
})
export class MemberComponent implements OnInit {
  members: Member[];
  userParams: UserParams;
  pagination: PaginationMember;
  user: IUser;
  genderList = [{ value: "male", display: "Male" }, { value: "female", display: "Female" }];


  constructor(private memberService: MemberService, private accountService: AccountService) {
 this.userParams = this.memberService.getUserParams();



    // gender:string ;
    // minAge=18;
    // maxAge=99 ;
    // pageNumber =5 ;
    // pageSize = 1 ;
  }

  ngOnInit(): void {
    this.loadMembers();
  }
  loadMembers() {
    this.memberService.setUserParams(this.userParams);
    this.memberService.getMembers(this.userParams).subscribe((response) => {
      this.members = response.result;
      this.pagination = response.pagination;
    })
  }
  pageChanged(event: any) {
    this.userParams.pageNumber = event.page;
    this.memberService.setUserParams(this.userParams);
    this.loadMembers();
  }

  resetFilters() {
    this.userParams = this.memberService.resetFilters();
    this.loadMembers();
  }
}
