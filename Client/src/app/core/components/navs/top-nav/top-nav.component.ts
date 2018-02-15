import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';

import { AssignTopNavService } from '../../../_services/assign-top-nav.service';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.scss']
})
export class TopNavComponent implements OnInit, OnDestroy {
  public topNav: any = [];
  topNavSubscription: Subscription;
  
  constructor(private assignTopNavService: AssignTopNavService, private router: Router) { }

  ngOnInit() {
    this.topNavSubscription = this.assignTopNavService.currentMenu.subscribe(topNav => this.topNav = topNav);
  }

  signOut(){
    localStorage.removeItem(this.topNav[0][0].link1);
    this.router.navigate(['/guest/home']);
  }

  ngOnDestroy() {
    if(this.topNavSubscription){
      this.topNavSubscription.unsubscribe();
    }
  }
}
