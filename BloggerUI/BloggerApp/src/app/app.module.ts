import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BlogComponent } from './blog/blog.component';
import { ShowBlogComponent } from './blog/show-blog/show-blog.component';
import { AddEditBlogComponent } from './blog/add-edit-blog/add-edit-blog.component';
import { UserComponent } from './user/user.component';
import { ShowUserComponent } from './user/show-user/show-user.component';
import { AddEditUserComponent } from './user/add-edit-user/add-edit-user.component';
import { BloggerApiService } from './common/blogger-api.service';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './user/login/login.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastContainerModule, ToastrModule } from 'ngx-toastr';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { ErrorComponent } from './error/error.component';
import { UserRouteActivator } from './user/login/user-route-activator.service';
import { BloggerToastrService } from './common/blogger-toastr.service';
import { HomeComponent } from './home/home.component';
import { ShowPostComponent } from './home/show-post/show-post.component';


@NgModule({
  declarations: [
    AppComponent,
    BlogComponent,
    ShowBlogComponent,
    AddEditBlogComponent,
    UserComponent,
    ShowUserComponent,
    AddEditUserComponent,
    LoginComponent,
    UserRegisterComponent,
    ErrorComponent,
    HomeComponent,
    ShowPostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [BloggerApiService, UserRouteActivator, BloggerToastrService],
  bootstrap: [AppComponent]
})
export class AppModule { }
