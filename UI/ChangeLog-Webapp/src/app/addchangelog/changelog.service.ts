import { Injectable } from '@angular/core';  
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Changelogmodel } from './changelogmodel';  
  
//After that we write all methods related to consume web in changelogService.service.ts  
 @Injectable({  
  providedIn: 'root'  
})  
  
export class ChangelogService {  
  public selectedLog:Changelogmodel;
  public allChangelogs: Observable<Changelogmodel[]>; 
  url = 'https://localhost:44300/api/ChangeLog';  
  constructor(private http: HttpClient) { }  
  getAllChangelog(): Observable<Changelogmodel[]> { 
    let httpHeaders = new HttpHeaders();
    httpHeaders = httpHeaders.append('Authorization', 'Bearer ' +   localStorage.getItem('jwt_token') );
    httpHeaders = httpHeaders.append('Content-Type', 'application/json' );
    let options = {headers:httpHeaders};
    
    return this.http.get<Changelogmodel[]>(this.url,options);
  }  
  post(changelog: Changelogmodel): Observable<Changelogmodel> {  
    let httpHeaders = new HttpHeaders();
    httpHeaders = httpHeaders.append('Authorization', 'Bearer ' +   localStorage.getItem('jwt_token') );
    httpHeaders = httpHeaders.append('Content-Type', 'application/json' );
    let options = {headers:httpHeaders}; 
    return this.http.post<Changelogmodel>(this.url ,  
      changelog, options);  
  }  
  put(changelog: Changelogmodel): Observable<Changelogmodel> {  
    let httpHeaders = new HttpHeaders();
    httpHeaders = httpHeaders.append('Authorization', 'Bearer ' +   localStorage.getItem('jwt_token') );
    httpHeaders = httpHeaders.append('Content-Type', 'application/json' );
    let options = {headers:httpHeaders};  
    return this.http.put<Changelogmodel>(this.url,  
      changelog, options);  
  }  
  delete(changelogid: string): Observable<number> {   
    let httpHeaders = new HttpHeaders();
    httpHeaders = httpHeaders.append('Authorization', 'Bearer ' +   localStorage.getItem('jwt_token') );
    httpHeaders = httpHeaders.append('Content-Type', 'application/json' );
    let options = {headers:httpHeaders};  
    return this.http.delete<number>(this.url + '/' +changelogid,  
    options);  
  }  
}  