import { ShardModule } from './../shard/shard.module';
import { NgxGalleryModule } from 'ngx-gallery-9';

import { MemberCardComponent } from './member-card/member-card.component';
import { NgModule } from '@angular/core';
import { MemberRoutingModule } from './member-routing.module';
import { MemberComponent } from './member.component';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
 import { CommonModule } from '@angular/common';
import { MemberEditComponent } from './member-edit/member-edit.component';
import { FormsModule } from '@angular/forms';
import { PhotoEditorComponent } from './photo-editor/photo-editor.component';
import { FileUploadModule } from 'ng2-file-upload';

import {BsDatepickerModule} from 'ngx-bootstrap/datepicker'

@NgModule({
  declarations: [
    MemberComponent,
    MemberCardComponent,
    MemberDetailComponent,
    MemberEditComponent,
    PhotoEditorComponent,

  ],
  imports: [
    CommonModule,
    MemberRoutingModule, TabsModule.forRoot(),
    NgxGalleryModule,
    FormsModule,
    FileUploadModule ,
     ShardModule
    ]

})
export class MemberModule { }
