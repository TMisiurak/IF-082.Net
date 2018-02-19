import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AssignTopNavService } from '../core/_services/assign-top-nav.service';

import { registryTopNav } from '../shared/_shared/menu/top-nav';

@Component({
  selector: 'app-registry',
  templateUrl: './registry.component.html',
  styleUrls: ['./registry.component.scss']
})
export class RegistryComponent implements OnInit {

  constructor(private assignTopNavService: AssignTopNavService, private router: Router) { }

  ngOnInit() {
    this.assignTopNavService.changeMenu(registryTopNav)
  }

  signOut(){
    localStorage.removeItem('admin');
    this.router.navigate(['/guest/home']);
  }
}
