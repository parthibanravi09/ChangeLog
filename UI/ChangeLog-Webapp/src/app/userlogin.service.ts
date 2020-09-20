import { Injectable } from '@angular/core';  
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Loginmodel } from './loginmodel';  
  
//After that we write all methods related to consume web in changelogService.service.ts  
 @Injectable({  
  providedIn: 'root'  
})  
  
export class UserloginService { 
  ErrorMsg:string; 
  loginStatus: boolean;
  url = 'https://localhost:44300/api/user/login';  
  constructor(private http: HttpClient) { }  
  login(loginmodel: Loginmodel) {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<any>(this.url,  
      loginmodel, httpOptions);  
  }
}  