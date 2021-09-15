import { Component } from '@angular/core';
import { BloggerApiService } from './common/blogger-api.service';
import { BloggerToastrService } from './common/blogger-toastr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BloggerApp'

  isUserloggedin: boolean = false

  constructor(private toastr:BloggerToastrService) {

  }

  ngAfterContentChecked() {
    var localUser = localStorage.getItem("user");
    if (localUser) {
      this.isUserloggedin = true
    }
    else {
      this.isUserloggedin = false
    }
  }

  userLogout() {
    localStorage.clear()
    this.toastr.info("User Logout")
    window.location.href="/login"
  }

}
