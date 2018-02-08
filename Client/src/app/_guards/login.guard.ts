import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable()
export class LoginGuard implements CanActivate {
	
	constructor( private router: Router ){ }

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
		if(localStorage.getItem('token') && JSON.parse(localStorage.getItem('token')).access_token){
			return true;
		}
		this.router.navigate(['/login']);
        return false;
	}
}
