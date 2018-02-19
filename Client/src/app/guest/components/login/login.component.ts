import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { NgModel, FormControl, Validators } from '@angular/forms';

import { Subscription } from 'rxjs/Subscription';

import { UserCredentials } from '../../_shared/models/UserCredentials';
import { HttpLoginService } from '../../_services/http-login.service';
import { JwtDecoderService } from '../../../core/_services/jwt-decoder.service';
import { CheckTokenService } from '../../../core/_services/check-token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  	public userCredentials: UserCredentials = new UserCredentials();
	private httpSubscription: Subscription;

	constructor( private httpLoginService: HttpLoginService, private jwtDecoder: JwtDecoderService, private router: Router,
		private checkTokenService: CheckTokenService ){ }

	ngOnInit(){
	}

	credentials(userCredentials: UserCredentials): string{
		return `grant_type=password&username=${userCredentials.email}&password=${userCredentials.password}&client_id=js&scope=api1 profile openid`;
	}

	signIn(credentials: string){
		this.httpSubscription = this.httpLoginService.login(credentials).subscribe(
			data => {
				if(data.access_token){
					let role = this.jwtDecoder.getJwtPayload(JSON.stringify(data)).role;
					if(role === 'admin'){
						localStorage.setItem('registry', JSON.stringify(data));
						this.router.navigate(['/registry']);
					}else{
						localStorage.setItem(role, JSON.stringify(data));
						if(role === 'patient'){
							this.router.navigate(['/patient']);
						}else if(role === 'doctor'){
							this.router.navigate(['/doctor']);
						}else if(role === 'accountant'){
							this.router.navigate(['/accountant']);
						}else{
							this.router.navigate(['/**']);
						}
					}
				}
			},
			err => {
				if( err === 400 ){
					this.router.navigate(['/**']);
				}
			});
	}

	ngOnDestroy(){
		if(this.httpSubscription){
			this.httpSubscription.unsubscribe();
		}
	}
}
