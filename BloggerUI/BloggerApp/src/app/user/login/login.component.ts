import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup } from '@angular/forms';
import { BloggerApiService } from 'src/app/common/blogger-api.service';
import { BloggerToastrService } from 'src/app/common/blogger-toastr.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private service:BloggerApiService, private toastrService:BloggerToastrService) { }

  loginFormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });
  
  activateLogOutCom:boolean=false

  ngOnInit(): void {
  }

  userLogin()
  {
    var  values=this.loginFormGroup.value;
    this.service.userLoginPost(values).subscribe(data => {
      
      var email = data.email
      var id = data.id
      var userData = {"id":id,"email":email}

      localStorage.clear()

      localStorage.setItem("user",JSON.stringify(userData)) 
      
      this.activateLogOutCom=true

      this.service.isLogged=true

      this.toastrService.success("Welcome","Login Success") 

      window.location.href="/home"
    },
    error=>{
      debugger
      this.activateLogOutCom=false
      localStorage.clear()
      this.toastrService.error("Login Failed","Error")
    },
    () => {
      // 'onCompleted' callback.
      // No errors, route to new page here
    });
  }

  userRegisterForm()
  {
    window.location.href="/register"
  }

}
