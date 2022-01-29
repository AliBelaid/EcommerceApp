import { PreventUnsavedChangesGuard } from './../core/guards/prevent-unsaved-changes.guard';
import { MemberEditComponent } from './member-edit/member-edit.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberComponent } from './member.component';



const routes: Routes = [
  {
    path: '', component: MemberComponent
  },  {
    path: 'edit', component: MemberEditComponent, canDeactivate:[PreventUnsavedChangesGuard]
  },
  {
    path: ':username', component: MemberDetailComponent
  },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MemberRoutingModule { }
