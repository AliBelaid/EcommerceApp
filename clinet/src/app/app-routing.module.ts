import { MemberDetailComponent } from './member/member-detail/member-detail.component';
import { AuthGuard } from './core/guards/auth.guard';
 import { ServerErrorComponent } from './core/server-error/server-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { MemberComponent } from './member/member.component';

const routes: Routes = [

  { path: '', component: HomeComponent ,data:{breadcrumb:'Home'}},
   { path: 'test-error', component: TestErrorComponent,data:{breadcrumb: 'Test Errors'} },
   { path: 'not-found', component: NotFoundComponent ,data:{breadcrumb: 'Not Found'}},
   { path: 'server-error', component: ServerErrorComponent ,data:{breadcrumb: 'Server Errors'}},
  { path: 'shop', loadChildren:()=>import('./shop/shop.module').then(mod=>mod.ShopModule),data:{breadcrumb: 'Shop'},canActivate:[AuthGuard]},
  { path: 'basket', loadChildren:()=>import('./basket/basket.module').then(mod=>mod.BasketModule),data:{breadcrumb: 'basket'}},
  { path: 'checkout'  , loadChildren:()=>import('./checkout/checkout.module').then(mod=>mod.CheckoutModule),data:{breadcrumb: 'checkout'}  ,canActivate:[AuthGuard]},
  { path: 'order'  , loadChildren:()=>import('./order/order.module').then(mod=>mod.OrderModule),data:{breadcrumb: 'order'}  ,canActivate:[AuthGuard]},
  { path: 'account', loadChildren:()=>import('./account/account.module').then(mod=>mod.AccountModule),data:{breadcrumb: {skip:true}}},
    {path:'member', loadChildren:()=> import('./member/member.module').then(mod=>mod.MemberModule)},


 {path:'**',redirectTo: 'not-found', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
