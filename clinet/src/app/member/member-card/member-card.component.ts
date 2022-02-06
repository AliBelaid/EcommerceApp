import { UserParams } from './../../models/userParam';
import { ToastrService } from 'ngx-toastr';
import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/models/member';
import { MemberService } from '../member.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.scss'],
 })
export class MemberCardComponent implements OnInit {
@Input() member:Member;

constructor(private memberService: MemberService, private ToastrService: ToastrService) {



 }

  ngOnInit(): void {
  }

addLike(member: Member) {
this.memberService.addLike(member.displayName).subscribe(() => {
this.ToastrService.success('You have Liked '+member.displayName);
    });
  }
}
