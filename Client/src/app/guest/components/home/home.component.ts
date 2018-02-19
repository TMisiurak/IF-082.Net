import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {
	
  constructor(private router: Router) { }

  ngOnInit() {
    if(localStorage.getItem('registry')){
			this.router.navigate(['/registry']);		
		}else if(localStorage.getItem('patient')){
			this.router.navigate(['/patient']);	
		}else if(localStorage.getItem('doctor')){
			this.router.navigate(['/doctor']);	
		}else if(localStorage.getItem('accountant')){
			this.router.navigate(['/accountant']);	
		}else{
			this.router.navigate(['/guest/home']);	
		}
  }
}
