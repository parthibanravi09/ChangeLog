import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes} from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { ChangelogComponent } from './addchangelog/changelog/changelog.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UserloginComponent } from './userlogin/userlogin.component';
import { AddchangelogComponent } from './addchangelog/addchangelog.component';
import{ChangelogformComponent} from './addchangelog/changelogform/changelogform.component'
const appRoutes: Routes = [
  {
     path: '',
     component: UserloginComponent
  },  
  {
    path: 'login',
    component: UserloginComponent
 },
  {
     path: 'home',
      component: AddchangelogComponent,
  }
];

@NgModule({
  declarations: [
    AppComponent,
    ChangelogComponent,
    UserloginComponent,
    AddchangelogComponent,
    ChangelogformComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),  
    FormsModule,  
    ReactiveFormsModule, 
    ToastrModule.forRoot(), 
    HttpClientModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
