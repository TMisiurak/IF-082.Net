import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';

import { AppComponent } from './app.component';

import { LoginGuard } from './core/guards/login.guard';

import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule, CommonModule, FormsModule, ReactiveFormsModule, HttpModule, RouterModule,
    CoreModule, SharedModule, 

    AppRoutingModule
  ],
  providers: [LoginGuard],
  bootstrap: [AppComponent],
})
export class AppModule { }
