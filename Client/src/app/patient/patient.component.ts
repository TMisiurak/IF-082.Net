import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { NgModel } from '@angular/forms';

import { Subscription } from 'rxjs/Subscription';

import { GetUserService } from '../core/services/get-user.service';
import { CheckTokenService } from '../core/services/check-token.service';
import { JwtDecoderService } from '../core/services/jwt-decoder.service';
import { AssignTopNavService } from '../core/services/assign-top-nav.service';
import { AssignSideNavService } from '../core/services/assign-side-nav.service';

import { patientTopNav } from '../shared/helpers/menu/top-nav';
import { patientSideNav } from '../shared/helpers/menu/side-nav';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent implements OnInit, OnDestroy {
  private httpSubscription: Subscription;
  public patientInfo: any = [];
  public done: boolean = false;

  constructor(private assignTopNavService: AssignTopNavService, private assignSideNavService: AssignSideNavService,
    private router: Router, private getUserService: GetUserService, private checkTokenService: CheckTokenService,
    private jwtDecodeService: JwtDecoderService) { }

  ngOnInit() {
    if(this.checkTokenService.checkToken('patient')){
      this.httpSubscription = this.getUserService
        .getUser(this.jwtDecodeService.getJwtPayload(this.checkTokenService.jwtLocal).sub,
          this.checkTokenService.authorizationToken)
        .subscribe(
          data => {
            if(data){
                this.patientInfo = data;
                patientTopNav[2][0].profile = data;
                patientSideNav[2][0].profile = data;
                this.assignTopNavService.changeMenu(patientTopNav);
                this.assignSideNavService.changeMenu(patientSideNav);
                this.done = true;
            }else{
                this.done = false;
            }
          },
          err => {
            if(err === 401){
                localStorage.removeItem('patient');
                this.router.navigate(['/guest/login']);
            }
          });
    }else{
      localStorage.removeItem('patient');
      this.router.navigate(['/guest/login']);
    }
  }

  signOut(){
    localStorage.removeItem('patient');
    this.router.navigate(['/guest/home']);
  }

  ngOnDestroy(){
    if(this.httpSubscription){
      this.httpSubscription.unsubscribe();
    }
  }
}
