import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserloginService } from '../userlogin.service';
import { Loginmodel } from '../loginmodel';
import { ActivatedRoute } from '@angular/router'; 
import { Observable } from 'rxjs';  


@Component({
  selector: 'app-userlogin',
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent implements OnInit {
  formdata;
  UserType: string;
  login = new Loginmodel();
  success:boolean = false;

  constructor(public router: Router,private route: ActivatedRoute, public service: UserloginService) {
    this.service.ErrorMsg = "";
    this.route.queryParams.subscribe(params => {
      let token = params['token'];
      let error = params['error'];
      
      if(token != null)
      {
        localStorage.setItem('jwt_token', token);
        sessionStorage.setItem('login', JSON.stringify({user:"google"}));
        this.success = true;
      }
      else if(error != null)
      {
        alert(error);
      }
       
  });
  }


  ngOnInit() {
    
    var userInfo = sessionStorage.getItem('login');
  console.log(userInfo);
    if (userInfo == null) {

    }
    else
    {
      this.router.navigate(['home']);
    }
  }

  passwordvalidation(formcontrol) {
    if (formcontrol.value.length < 5) {
      return { "passwd": true };
    }
  }

  onClickSubmit(form: NgForm) {
    this.service.loginStatus = false;    

    let login:Loginmodel = new Loginmodel();
    login.password = form.value.Password;
    login.userName = form.value.UserName;
    this.service.login(login).subscribe((data: any) => {
   
      if (data.token !== 'undefined') {

        // Stores access token & refresh token. 
        this.store(data);
        sessionStorage.setItem('login', JSON.stringify(login));
        this.router.navigate(['home'])
      } else {
        this.service.ErrorMsg = "Username, password or combination of both is invalid.";
      }
    },(error) => {                              //Error callback
      if(error.status == 400)
      {
        this.service.loginStatus = true;
        this.service.ErrorMsg = "Username, password or combination of both is invalid."
      }
      else
      {
        
        this.service.loginStatus = true;
        this.service.ErrorMsg = "Server error."
      }

      //throw error;   //You can also throw the error to a global error handler
    });
  }

  

  private store(body: any): void {

    // Stores access token in local storage to keep user signed in.  
    localStorage.setItem('jwt_token', body.token);
  }

}
