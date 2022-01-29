import { MemberService } from './../member.service';
import { IUser } from './../../models/user';
import { AccountService } from './../../account/account.service';
import { environment } from './../../../environments/environment';
import { Member } from './../../models/member';
import { Component, Input, OnInit } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';
import { FileWatcherEventKind } from 'typescript';
import { Photo } from 'src/app/models/photo';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.scss']
})
export class PhotoEditorComponent implements OnInit {
@Input() member: Member;
uploader:FileUploader;
hasBaseDropZoneOver =false;
baseUrl= environment.apiUrl ;
user:IUser ;
response:string;
  constructor(private accountService:AccountService , private memberService:MemberService) {
this.accountService.currentUser$.subscribe((rep) => this.user =rep);
   }

  ngOnInit() {
    this.initializeUploader();
  }
  fileOverBase(e:any) {
    this.hasBaseDropZoneOver = e ;
  }
initializeUploader(){
this.uploader = new FileUploader({
url:this.baseUrl +'User/add-photo',
authToken: 'Bearer '+ this.user.token ,
isHTML5: true ,
allowedFileType: ['image'],
removeAfterUpload:true ,
autoUpload:false ,
maxFileSize:10*1024*1024
});

this.uploader.onAfterAddingAll = (file) => {
  file.withCredentials = false
}
this.uploader.onSuccessItem = (item ,response ,status , headers)=> {
  if(response) {
    const photo  = JSON.parse(response);
    this.member.photos.push(photo);
  }
}
}

setMainPhoto(photo :Photo) {
  this.memberService.setMainPhoto(photo.id).subscribe(() => {
    this.user.photoUrl = photo.url ;
    this.accountService.setCurrentUser(this.user);
    this.member.photoUrl = photo.url ;
    this.member.photos.forEach(p=> {
      if(p.isMain) {
                p.isMain = false ;
      }
      if(p.id=== photo.id) p.isMain =true;
    })

  })
  }


  deletePhoto(photo :Photo) {
    this.memberService.deletePhoto(photo.id).subscribe(() => {

      this.member.photos= this.member.photos.filter(x=>x.id !== photo.id) ;

    });
    }
}
