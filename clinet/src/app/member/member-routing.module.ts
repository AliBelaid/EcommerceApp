
import { PreventUnsavedChangesGuard } from './../core/guards/prevent-unsaved-changes.guard';
import { MemberEditComponent } from './member-edit/member-edit.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberComponent } from './member.component';
import { ListsComponent } from '../lists/lists.component';




const routes: Routes = [

  {
    path: 'member', component: MemberComponent
  },
   { path: 'list', component: ListsComponent },
  {
    path: 'member/edit', component: MemberEditComponent, canDeactivate:[PreventUnsavedChangesGuard]
  },
  {
    path: 'member/:username', component: MemberDetailComponent
  }


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRoutingModule { }
