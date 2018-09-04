import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {FormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { BsDatepickerModule} from 'ngx-bootstrap/datepicker';

import { HomeComponent } from './home/home.component';
import { SingUpComponent } from './sing-up/sing-up.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SingUpComponent 
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BsDatepickerModule.forRoot(),
    RouterModule.forRoot([
      {
        path: 'home',
        component: HomeComponent
      },
      {
        path: 'sing-up',
        component: SingUpComponent
      },
      {
        path: ' ',
        component: HomeComponent
      }
    
  ]),
],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
