import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { NgModel } from '@angular/forms';

import { Subscription } from 'rxjs/Subscription';

import { GetUserService } from '../core/services/get-user.service';
import { CheckTokenService } from '../core/services/check-token.service';
import { JwtDecoderService } from '../core/services/jwt-decoder.service';
import { AssignTopNavService } from '../core/services/assign-top-nav.service';

import { registryTopNav } from '../shared/helpers/menu/top-nav';

@Component({
  selector: 'app-registry',
  templateUrl: './registry.component.html',
  styleUrls: ['./registry.component.scss']
})
export class RegistryComponent implements OnInit, OnDestroy {
  private httpSubscription: Subscription;
  public registryInfo: any = [];
  public done: boolean = false;

  constructor(private assignTopNavService: AssignTopNavService, private router: Router,
    private getUserService: GetUserService, private checkTokenService: CheckTokenService,
    private jwtDecodeService: JwtDecoderService) { }

  ngOnInit() {
    if(this.checkTokenService.checkToken('registry')){
      this.httpSubscription = this.getUserService
        .getUser(this.jwtDecodeService.getJwtPayload(this.checkTokenService.jwtLocal).sub,
          this.checkTokenService.authorizationToken)
        .subscribe(
          data => {
            if(data){
                this.registryInfo = data;
                registryTopNav[2][0].profile = data;
                this.assignTopNavService.changeMenu(registryTopNav)
                this.done = true;
            }else{
                this.done = false;
            }
          },
          err => {
            if(err === 401){
                localStorage.removeItem('registry');
                this.router.navigate(['/guest/login']);
            }
          });
    }else{
      localStorage.removeItem('registry');
      this.router.navigate(['/guest/login']);
    }
  }

  signOut(){
    localStorage.removeItem('registry');
    this.router.navigate(['/guest/home']);
  }

  ngOnDestroy(){
    if(this.httpSubscription){
      this.httpSubscription.unsubscribe();
    }
  }
}
