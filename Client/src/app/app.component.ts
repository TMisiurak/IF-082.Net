import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';

import { AssignSideNavService } from '../app/core/services/assign-side-nav.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public topNav: any = [];
  sideNavSubscription: Subscription;

  constructor(private assignSideNavService: AssignSideNavService, private router: Router) { }

  ngOnInit() {
    this.sideNavSubscription = this.assignSideNavService.currentMenu.subscribe(topNav => this.topNav = topNav);
  }

  ngOnDestroy() {
    if (this.sideNavSubscription) {
      this.sideNavSubscription.unsubscribe();
    }
  }
}
