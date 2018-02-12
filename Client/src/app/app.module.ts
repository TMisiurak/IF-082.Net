import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { CoreModule } from './core/core.module';
import { GuestModule } from './guest/guest.module';

import { AppComponent } from './app.component';

import { LoginGuard } from './_guards/login.guard';

import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule, CommonModule, FormsModule, ReactiveFormsModule, HttpModule, RouterModule,
    CoreModule, GuestModule,

    AppRoutingModule
  ],
  providers: [LoginGuard],
  bootstrap: [AppComponent],
})
export class AppModule { }
