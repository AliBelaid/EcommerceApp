import { PaginationResult, PaginationMember } from './../models/paginationMember';
import { Member } from 'src/app/models/member';
import { Component, OnInit } from '@angular/core';
import { MemberService } from '../member/member.service';



@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.scss']
})
export class ListsComponent implements OnInit {
   members: Partial<Member[]> ;
   pagination: PaginationMember ;
   predicate = 'liked';
   pageNumber = 1;
   pageSize =5 ;
  constructor(private memberService:MemberService) { }

  ngOnInit() {
    this.loadLikes();
  }

  loadLikes(){
   this.memberService.getLikes(this.predicate ,this.pageNumber,this.pageSize).subscribe((response) => {

    this.pagination = response.pagination ;
    this.members =response.result ;
    console.log(this.members);
   });

  }

 pageChanged(event: any) {
 this.pageNumber = event.page;

  this.loadLikes();
}
}
