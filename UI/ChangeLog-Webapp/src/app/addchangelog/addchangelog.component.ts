import { Component, OnInit } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addchangelog',
  templateUrl: './addchangelog.component.html',
  styleUrls: ['./addchangelog.component.css']
})
export class AddchangelogComponent implements OnInit {

  constructor(public router: Router) { }

  ngOnInit() {
  }
  onLogout()
  {
    
    sessionStorage.removeItem('login');
    localStorage.removeItem('id_token');
    
    this.router.navigate(['login']);
  }

}
