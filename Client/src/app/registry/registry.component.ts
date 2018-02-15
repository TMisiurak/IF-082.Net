import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AssignTopNavService } from '../core/_services/assign-top-nav.service';

@Component({
  selector: 'app-registry',
  templateUrl: './registry.component.html',
  styleUrls: ['./registry.component.scss']
})
export class RegistryComponent implements OnInit {
  private topNav: any = [
    {link1: "registry", link2: "registry1", name: "Registry1"},
    {link1: "registry", link2: "registry2", name: "Registry2"},
    {link1: "registry", link2: "registry3", name: "Registry3"}
  ];

  constructor(private assignTopNavService: AssignTopNavService, private router: Router) { }

  ngOnInit() {
    this.newMenu();
  }

  newMenu() {
    this.assignTopNavService.changeMenu(this.topNav)
  }

  signOut(){
    localStorage.removeItem('admin');
    this.router.navigate(['/guest/home']);
  }
}
