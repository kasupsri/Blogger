import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BloggerApiService } from 'src/app/common/blogger-api.service';
import { BloggerToastrService } from 'src/app/common/blogger-toastr.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {

  constructor(private service: BloggerApiService, private toastr: BloggerToastrService) { }

  registerFormGroup = new FormGroup({
    id: new FormControl(0),
    name: new FormControl(''),
    email: new FormControl(''),
    phone: new FormControl(''),
    password: new FormControl('')
  });

  ngOnInit(): void {
  }

  userRegister() {
    var values = this.registerFormGroup.value;
    this.service.userRegister(values).subscribe(data => {
      this.toastr.success("Uer registred")
      window.location.href = "/login"
    },
      response => {
        debugger
        //find a way to show those erros
        var msgs = response.error.errors
        this.toastr.error("User register error")
      },
      () => {

      });
  }

  userCancel() {
    window.location.href = "/login"
  }

}
