import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { NgModel } from '@angular/forms';

import { GetUserService } from '../core/_services/get-user.service';
import { CheckTokenService } from '../core/_services/check-token.service';
import { JwtDecoderService } from '../core/_services/jwt-decoder.service';

import { Patient } from './_shared/models/patient';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss']
})
export class PatientComponent implements OnInit, OnDestroy {
  private httpSubscription: Subscription;
  public patientInfo: any = [];
  public nick: string = "";
  public done: boolean = false;

  constructor(private router: Router, private getUserService: GetUserService, private checkTokenService: CheckTokenService,
    private jwtDecodeService: JwtDecoderService) { }

  ngOnInit() {
    if(this.checkTokenService.checkToken('patient')){
      this.httpSubscription = this.getUserService.getUser(this.jwtDecodeService.getJwtPayload(this.checkTokenService.jwtLocal).sub, this.checkTokenService.authorizationToken).subscribe(
        data => {
            if(data){
                this.patientInfo = data;
                this.nick = this.patientInfo.fullName.slice(0, 2);
                this.done = true;
            }else{
                this.done = false;
            }
        },
        err => {
            if(err === 401){
                localStorage.removeItem('patient');
                this.router.navigate(['/login']);
            }
        });
      }else{
        localStorage.removeItem('patient');
        this.router.navigate(['/login']);
      }
  }

  signOut(){
    localStorage.removeItem('patient');
    this.router.navigate(['/login']);
  }

  ngOnDestroy(){
    if(this.httpSubscription){
      this.httpSubscription.unsubscribe();
    }
  }
}
