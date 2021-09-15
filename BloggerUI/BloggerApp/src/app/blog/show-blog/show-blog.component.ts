import { Component, OnInit } from '@angular/core';
import { BloggerApiService } from 'src/app/common/blogger-api.service'; 
import { BloggerToastrService } from 'src/app/common/blogger-toastr.service';

@Component({
  selector: 'app-show-blog',
  templateUrl: './show-blog.component.html',
  styleUrls: ['./show-blog.component.css']
})
export class ShowBlogComponent implements OnInit {

  constructor(private service:BloggerApiService, private toastr:BloggerToastrService) { }

  blogList:any=[]

  modalTitle:string=""
  activateAddEditBlogComp:boolean=false
  blog:any
  user:any=[]

  ngOnInit(): void {
    var localData = localStorage.getItem("user")
    if (localData) {
      this.user = JSON.parse(localData)
    }
    else {
      this.toastr.info("Please login")
      window.location.href = "/login"
    }
    this.refreshBlogList()
  }

  refreshBlogList(){
    this.service.getUserBlogPosts(this.user.id).subscribe(data => {
        this.blogList=data;
        this.toastr.success("Blogs Loaded")
    },
    error=>{
      // on error
      this.toastr.error("Error")
    },
    () => {
      // 'onCompleted' callback.
      // No errors, route to new page here
    });
  }

  addClick(){
    this.blog={
      id:0,
      subject:"",
      post:"",
      isPublished:false
    }
    this.modalTitle="Add Blog Post"
    this.activateAddEditBlogComp=true
  }

  editClick(item:any){
    this.blog=item;
    this.modalTitle="Edit Blog Post"
    this.activateAddEditBlogComp=true
  }

  deleteClick(item:any){
    if(confirm('Are you sure??')){
      this.service.deleteBlogPost(item.id).subscribe(data=>{
        this.refreshBlogList();
        this.toastr.success("Blog post deleted")
      },
      error=>{
        // on error
        this.toastr.error("Blog post delete error")
      },
      () => {
        // 'onCompleted' callback.
        // No errors, route to new page here
      })
    }
  }

  closeClick(){
    this.activateAddEditBlogComp=false
    this.refreshBlogList()
  }

}
