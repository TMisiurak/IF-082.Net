import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable()
export class LoginGuard implements CanActivate {
	
	constructor( private router: Router ){ }

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
		if(localStorage.getItem('admin') || localStorage.getItem('patient') ||
				localStorage.getItem('doctor') || localStorage.getItem('accountant')){
			return true;
		}
		this.router.navigate(['/login']);
        return false;
	}
}
