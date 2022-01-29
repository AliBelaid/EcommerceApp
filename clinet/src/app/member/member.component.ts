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

   members$:Observable<Member[]>;
  constructor(private memberService:MemberService) { }

  ngOnInit(): void {
   this.members$ = this.memberService.getMembers();// this.leadMembers();
  }

}
