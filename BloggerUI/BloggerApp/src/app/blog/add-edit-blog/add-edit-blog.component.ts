import { Component, OnInit, Input } from '@angular/core';
import { BloggerApiService } from 'src/app/common/blogger-api.service';
import { BloggerToastrService } from 'src/app/common/blogger-toastr.service';

@Component({
  selector: 'app-add-edit-blog',
  templateUrl: './add-edit-blog.component.html',
  styleUrls: ['./add-edit-blog.component.css']
})
export class AddEditBlogComponent implements OnInit {

  constructor(private service: BloggerApiService, private toastr:BloggerToastrService) { }


  @Input() blog: any
  subject: string = ""
  post: string = ""
  isPublished: boolean = false
  user:any=[]

  ngOnInit(): void {
    var localUser = localStorage.getItem("user")
    if(localUser)
    {
      this.user = JSON.parse(localUser)
    }
    else
    {
      this.toastr.info("Please login")
      window.location.href="/login"
    }
    this.subject = this.blog.subject
    this.post = this.blog.post
    this.isPublished = this.blog.isPublished
  }

  addBlogPost() {
    var val = {
      id: 0,
      subject: this.subject,
      post: this.post,
      isPublished: this.isPublished,
      userId:this.user.id
    };
    this.service.addBlogPost(val).subscribe(res => {
      this.toastr.success("Blog Post Added")
      window.location.href="/blog"
    },
    error=>{
      // on error
      this.toastr.error("blog post add error")
    },
    () => {
      // 'onCompleted' callback.
      // No errors, route to new page here
    });
  }

  updateBlogPost() {
    var val = {
      id: this.blog.id,
      subject: this.subject,
      post: this.post,
      isPublished: this.isPublished,
      createdTime: this.blog.createdTime,
      updatedTime: new Date(),
      userId: this.user.id,
    };
    this.service.updateBlogPost(val).subscribe(res => {
      this.toastr.success("Blog Post Added")
      window.location.href="/blog"
    },
    error=>{
      // on error
      this.toastr.error("blog post update error")
    },
    () => {
      // 'onCompleted' callback.
      // No errors, route to new page here
    });
  }

}
