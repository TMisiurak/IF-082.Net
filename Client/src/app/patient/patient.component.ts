import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { NgModel } from '@angular/forms';

import { Subscription } from 'rxjs/Subscription';

import { GetUserService } from '../core/_services/get-user.service';
import { CheckTokenService } from '../core/_services/check-token.service';
import { JwtDecoderService } from '../core/_services/jwt-decoder.service';
import { AssignTopNavService } from '../core/_services/assign-top-nav.service';

import { Patient } from './_shared/models/patient';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent implements OnInit, OnDestroy {
  private httpSubscription: Subscription;
  public patientInfo: any = [];
  public done: boolean = false;
  private topNav: any = [
    [
      {link1: "patient", link2: "home", name: "Home"},
      {link1: "patient", link2: "patient2", name: "Patient2"},
      {link1: "patient", link2: "patient3", name: "Patient3"}
    ],
    [
      {link1: "patient", link2: "profile", name: "Profile"}
    ],
    [
      {profile: this.patientInfo, name: "Patient Info"}
    ]
  ];

  constructor(private assignTopNavService: AssignTopNavService, private router: Router, private getUserService: GetUserService, private checkTokenService: CheckTokenService,
    private jwtDecodeService: JwtDecoderService) { }

  ngOnInit() {
    if(this.checkTokenService.checkToken('patient')){
      this.httpSubscription = this.getUserService.getUser(this.jwtDecodeService.getJwtPayload(this.checkTokenService.jwtLocal).sub, this.checkTokenService.authorizationToken).subscribe(
        data => {
            if(data){
                this.patientInfo = data;
                this.topNav[2][0].profile = data;
                this.newMenu();
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

  newMenu() {
    this.assignTopNavService.changeMenu(this.topNav)
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
