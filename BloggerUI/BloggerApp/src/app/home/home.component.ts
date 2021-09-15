import { Component, OnInit } from '@angular/core';
import { BloggerApiService } from '../common/blogger-api.service';
import { BloggerToastrService } from '../common/blogger-toastr.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private service:BloggerApiService, private toastr:BloggerToastrService) { }

  blogList:any=[]
  modalTitle:string=""
  activateAddEditBlogComp:boolean=false
  blog:any

  ngOnInit(): void {
    this.refreshBlogList();
    this.modalTitle="All Blog Posts"
  }

  refreshBlogList(){
    this.service.getBlogPosts().subscribe(data => {
        this.blogList=data;
        this.toastr.success("Blogs Loaded")
    },
    error=>{
      // on error
      this.toastr.error("Blogs load error")
    },
    () => {
      // 'onCompleted' callback.
      // No errors, route to new page here
    });
  }

  showClick(item:any){
    this.blog=item
    this.modalTitle="Detail Blog Post"
    this.activateAddEditBlogComp=true
  }

  closeClick(){
    this.activateAddEditBlogComp=false
    this.refreshBlogList()
  }

}
