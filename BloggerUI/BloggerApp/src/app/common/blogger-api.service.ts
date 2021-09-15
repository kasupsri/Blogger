import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BloggerApiService {

  isLogged:boolean=false;

  readonly APIUrl = "https://localhost:44368/api";

  constructor(private http: HttpClient) { }

  getBlogPosts(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/BlogPosts');
  }

  getUserBlogPosts(val:any): Observable<any[]> {
    let endPoint = this.APIUrl + '/BlogPosts/user/' + val; 
    return this.http.get<any>(endPoint);
  }

  addBlogPost(val: any) {
    return this.http.post(this.APIUrl + '/BlogPosts', val);
  }

  updateBlogPost(val: any) {
    let endPoint = this.APIUrl + '/BlogPosts/' + val.id;
    return this.http.put(endPoint, val);
  }

  deleteBlogPost(val: any) {
    let endPoint = this.APIUrl + '/BlogPosts/' + val;
    return this.http.delete(endPoint);
  }

  userLoginPost(val: any) {
    return this.http.post<any>(this.APIUrl + '/Users/login', val);
  }

  userRegister(val: any) {
    return this.http.post<any>(this.APIUrl + '/Users', val);
  }

  getUser(val: any): Observable<any[]> {
    let endPoint = this.APIUrl + '/Users/' + val;
    return this.http.get<any>(endPoint);
  }

  updateUser(val: any) {
    debugger
    let endPoint = this.APIUrl + '/Users/' + val.id;
    return this.http.put<any>(endPoint, val);
  }

}
