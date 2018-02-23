import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { NgModel } from '@angular/forms';

import { AssignTopNavService } from '../core/services/assign-top-nav.service';

import { guestTopNav } from '../shared/helpers/menu/top-nav';
import { guestSideNav } from '../shared/helpers/menu/side-nav';
import { AssignSideNavService } from '../core/services/assign-side-nav.service';

@Component({
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.scss']
})

export class GuestComponent implements OnInit, OnDestroy {

  constructor(private assignTopNavService: AssignTopNavService, private assignSideNavService: AssignSideNavService,
    private router: Router) { }

  ngOnInit() {
    this.assignTopNavService.changeMenu(guestTopNav)
    this.assignSideNavService.changeMenu(guestSideNav)
  }

  ngOnDestroy(){
    
  }
}
