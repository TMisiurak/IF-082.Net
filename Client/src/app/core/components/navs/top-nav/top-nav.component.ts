import { Component, OnInit, OnDestroy } from '@angular/core';

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
  
  constructor(private assignTopNavService: AssignTopNavService) { }

  ngOnInit() {
    this.topNavSubscription = this.assignTopNavService.currentMenu.subscribe(topNav => this.topNav = topNav);
  }

  ngOnDestroy() {
    if(this.topNavSubscription){
      this.topNavSubscription.unsubscribe();
    }
  }
}
