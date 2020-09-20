import { Component, OnInit } from '@angular/core';  
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import {ToastrService} from 'ngx-toastr';
import { ChangelogService } from '../changelog.service';  
import { Changelogmodel } from '../changelogmodel'; 
import { Router } from '@angular/router';

@Component({
  selector: 'app-changelog',
  templateUrl: './changelog.component.html',
  styleUrls: ['./changelog.component.css']
})
export class ChangelogComponent implements OnInit {
  
  constructor(public router: Router, private changelogService:ChangelogService, private toastr : ToastrService) { }  

  ngOnInit() {   
    var userInfo = sessionStorage.getItem('login');
    console.log(userInfo);

      if (userInfo == null) 
      {
        this.router.navigate(['login']);
      }
      else
      {
        this.loadAllChangelog();
      }      
    
  }

  loadAllChangelog() {  
    this.changelogService.allChangelogs = this.changelogService.getAllChangelog();  
    this.changelogService.allChangelogs.subscribe((data:any)=>{
     },(error) => {          
      this.handelError(error);
    });
  } 
  
  showForEdit(log: Changelogmodel) {
      this.changelogService.selectedLog = Object.assign({}, log);
 }

 onDelete(id: number) {
   if (confirm('Are you sure to delete this user?') == true) {
         
     
     this.changelogService.delete(id.toString()).subscribe((data:any)=>{
      this.loadAllChangelog();
       this.toastr.warning("Deleted Successfully","User Register");
     },(error) => {                             //Error callback
      
      this.handelError(error);
    });
   }
  }

  handelError(error:any)
  {
    if(error.status == 401)
    {
      alert("Session timeout login again.");
      this.onLogout();
    }
    else
    {        
      alert("Server error.");
    }
  }

  onLogout()
  {
    
    sessionStorage.removeItem('login');
    localStorage.removeItem('id_token');
    
    this.router.navigate(['login']);
  }

}
