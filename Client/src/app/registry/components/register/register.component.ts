import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { NgModel, FormControl, Validators } from '@angular/forms';

import { Subscription } from 'rxjs/Subscription';

import { Patient } from '../../shared/models/Patient';
import { HttpRegisterService } from '../../services/http-register.service';
import { JwtDecoderService } from '../../../core/services/jwt-decoder.service';
import { CheckTokenService } from '../../../core/services/check-token.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit, OnDestroy {
  public patient: Patient = new Patient();
  private httpSubscription: Subscription;
  public done: boolean = false;
  public error: boolean = false;

	constructor( private httpRegisterService: HttpRegisterService, private jwtDecodeService: JwtDecoderService, private router: Router,
		private checkTokenService: CheckTokenService ){ }

	ngOnInit(){
	}

	signUp(patient: any){
    if(this.checkTokenService.checkToken('registry')){
      this.patient.Image = "image";
      this.httpSubscription = this.httpRegisterService
        .register(patient, this.checkTokenService.authorizationToken)
        .subscribe(
          data => {
            if(data){
              this.patient = new Patient();
              this.router.navigate(['/registry/register']);
              this.done = true;
              this.error = false;
            }else{
              this.done = false;
              this.error = true;
            }
          },
          err => {
            if(err === 401){
              localStorage.removeItem('registry');
              this.router.navigate(['/guest/login']);
            }else{
              this.router.navigate(['/registry/register']);
              this.done = false;
              this.error = true;
            }
          });
    }else{
      localStorage.removeItem('registry');
      this.router.navigate(['/guest/login']);
    }
	}

	ngOnDestroy(){
		if(this.httpSubscription){
			this.httpSubscription.unsubscribe();
		}
	}
}
