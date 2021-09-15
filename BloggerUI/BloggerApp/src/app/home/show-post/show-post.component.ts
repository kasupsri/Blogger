import { Component, OnInit, Input } from '@angular/core';
import { BloggerApiService } from 'src/app/common/blogger-api.service';

@Component({
  selector: 'app-show-post',
  templateUrl: './show-post.component.html',
  styleUrls: ['./show-post.component.css']
})
export class ShowPostComponent implements OnInit {

  constructor(private service: BloggerApiService) { }

  @Input() blog: any

  ngOnInit(): void {
  }

}
