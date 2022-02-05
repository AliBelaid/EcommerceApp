import { Photo } from './../../models/photo';
import { ToastrService } from 'ngx-toastr';
import { IUser } from './../../models/user';
import { Member } from './../../models/member';
import { AccountService } from './../../account/account.service';
import { MemberService } from './../member.service';
import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { take } from 'rxjs/operators';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.scss']
})
export class MemberEditComponent implements OnInit {
  @ViewChild('editForm') editForm:NgForm;
member:Member;
user:IUser;
@HostListener('window:beforeunload',['$event']) unloadNotification($event:any){
if(this.editForm.dirty){
  $event.returnValue=true;
}
}
  constructor(private memberService:MemberService ,private accountService:AccountService ,private toastrService:ToastrService) {

  }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe(user=>{
      this.user = user ;
      this.loadMember();
     });

  }
loadMember(){
  this.memberService.getMember(this.user.displayName).subscribe(member => {
     this.member = member;

  });
}

updateMember(){
  console.log(this.member);
  this.memberService.updateMember(this.member).subscribe(()=> {
    this.toastrService.success('update Member');
    this.editForm.reset(this.member);
  } );

}


}
