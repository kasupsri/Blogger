import { Component, OnInit } from '@angular/core';
import { BloggerApiService } from 'src/app/common/blogger-api.service';
import { BloggerToastrService } from 'src/app/common/blogger-toastr.service';

@Component({
  selector: 'app-show-user',
  templateUrl: './show-user.component.html',
  styleUrls: ['./show-user.component.css']
})
export class ShowUserComponent implements OnInit {

  constructor(private service: BloggerApiService, private toastr:BloggerToastrService) { }

  localUser: any
  user: any

  ngOnInit(): void {
    var localData = localStorage.getItem("user")
    if (localData) {
      this.localUser = JSON.parse(localData);
    }
    else {
      this.toastr.info("Please login")
      window.location.href = "/login"
    }
    this.getUser()
  }

  getUser() {
    this.service.getUser(this.localUser.id).subscribe(data => {
      this.user = data;
      this.toastr.success("User loaded")
    },
      error => {
        // on error
        this.toastr.error("User load error")
        window.location.href = "/login"
      },
      () => {
        // 'onCompleted' callback.
        // No errors, route to new page here
      });
  }

  modifyUser(){
    debugger
    var val = {
      id: this.user.id,
      name: this.user.name,
      email: this.user.email,
      phone:this.user.phone,
      password: this.user.password
    };
    this.service.updateUser(val).subscribe(res => {
      this.toastr.success("User data updated")
    },
    error=>{
      // on error
      this.toastr.error("User update error")
    },
    () => {
      // 'onCompleted' callback.
      // No errors, route to new page here
    });
  }

}
