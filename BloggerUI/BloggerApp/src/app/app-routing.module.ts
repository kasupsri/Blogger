import { NgModule } from '@angular/core';
import { Routes, RouterModule, Router } from '@angular/router';

import { UserComponent } from './user/user.component';
import { BlogComponent } from './blog/blog.component';
import { LoginComponent } from './user/login/login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { ErrorComponent } from './error/error.component';
import { UserRouteActivator } from './user/login/user-route-activator.service';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [UserRouteActivator] },
  { path: 'home', component: HomeComponent, canActivate: [UserRouteActivator] },
  { path: 'login', component: LoginComponent },
  { path: 'user', component: UserComponent, canActivate: [UserRouteActivator] },
  { path: 'blog', component: BlogComponent, canActivate: [UserRouteActivator] },
  { path: 'register', component: UserRegisterComponent },
  { path: '404', component: ErrorComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

