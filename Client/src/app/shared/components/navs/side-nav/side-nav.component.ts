import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';

import { AssignSideNavService } from '../../../../core/services/assign-side-nav.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {
  public sideNav: any = [];
  sideNavSubscription: Subscription;

  constructor(private assignSideNavService: AssignSideNavService, private router: Router) { }

  ngOnInit() {
    this.sideNavSubscription = this.assignSideNavService.currentMenu.subscribe(sideNav => this.sideNav = sideNav);
  }

  // signOut() {
  //   localStorage.removeItem(this.sideNav[0][0].link1);
  //   this.router.navigate(['/guest/home']);
  // }

  ngOnDestroy() {
    if (this.sideNavSubscription) {
      this.sideNavSubscription.unsubscribe();
    }
  }

}
