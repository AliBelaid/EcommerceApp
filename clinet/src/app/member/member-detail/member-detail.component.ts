
import { ActivatedRoute } from '@angular/router';
import { MemberService } from './../member.service';
import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/models/member';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from 'ngx-gallery-9';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.scss']
})
export class MemberDetailComponent implements OnInit {
member:Member;
galleryOptions: NgxGalleryOptions[];
galleryImages: NgxGalleryImage[];
  constructor(private memberService:MemberService , private route:ActivatedRoute) {
    ////
  }

  ngOnInit(): void {
    this.memberService.getMember(this.route.snapshot.paramMap.get('username')).subscribe((resp)=> {
      this.member = resp;
      if(this.member?.photos.length> 0) {
        this.galleryImages = this.getImages() ;
      }

    },error=> {
      console.log(error);
    });
    this.galleryOptions = [
      {
        width: '600px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ]


   }

  getImages(): NgxGalleryImage[] {
    const imageUrls = [];

    for (const photo of this.member.photos) {
      imageUrls.push({
        small: photo?.url,
        medium: photo?.url,
        big: photo?.url
      })
    }
    return imageUrls;
  }


}
