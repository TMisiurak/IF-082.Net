import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { NgModel } from '@angular/forms';

import { AssignTopNavService } from '../core/_services/assign-top-nav.service';

@Component({
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.scss']
})

export class GuestComponent implements OnInit, OnDestroy {
  private httpSubscription: Subscription;
  public patientInfo: any = [];
  public nick: string = "";
  public done: boolean = false;
  private topNav: any = [
    [
      {link1: "guest", link2: "home", name: "Home"},
      {link1: "guest", link2: "guest1", name: "Guest1"},
      {link1: "guest", link2: "guest2", name: "Guest2"}
    ],
    [
      {link1: "guest", link2: "login", name: "Sign In"},
      {link1: "guest", link2: "register", name: "Sign Up"}
    ],
    [
      {profile: null, name: ""}
    ]
  ];

  constructor(private assignTopNavService: AssignTopNavService, private router: Router) { }

  ngOnInit() {
    this.newMenu();
  }

  newMenu() {
    this.assignTopNavService.changeMenu(this.topNav)
  }

  ngOnDestroy(){

  }
}
