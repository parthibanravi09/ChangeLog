import { Component, OnInit } from '@angular/core';
import { ChangelogService } from '../changelog.service';
import { NgForm } from '@angular/forms';
import { FormsModule} from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-changelogform',
  templateUrl: './changelogform.component.html',
  styleUrls: ['./changelogform.component.css']
})
export class ChangelogformComponent implements OnInit {

  formData:FormData;
  constructor(private changelogService:ChangelogService, private router: Router) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.changelogService.selectedLog = {
      no: null,
      type: '',
      content: '',
      updated:'',
      title:''
    }

    this.formData = null;
  }

  onSubmit(form: NgForm) {
   
    if (form.value.Id == null) {
      this.changelogService.post(form.value).subscribe((data:any)=>{
          this.resetForm(form);
          this.loadAllChangelog();
          alert("Added Successfully");         
        },(error) => {      
          this.handelError(error);
        });

        
    }
    else {
      console.log(form.value);
      this.changelogService.put(form.value).subscribe((data:any)=>{
        this.resetForm(form);
        this.loadAllChangelog();
        alert("Updated Successfully");
       
      },(error) => {      
        this.handelError(error);
      });
    }
  }

  loadAllChangelog() {  
    this.changelogService.allChangelogs = this.changelogService.getAllChangelog();  
    this.changelogService.allChangelogs.subscribe((data:any)=>{
    },(error) => {          
     this.handelError(error);
   });
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
