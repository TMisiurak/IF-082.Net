import { Injectable } from '@angular/core';
import { Http, Response, Headers, URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { apiUrl } from '../../shared/helpers/settings/Urls';

@Injectable()
export class HttpRegisterService {
	
  constructor(private http: Http){ }   

  register(patient: any, token: string){
    let headers = new Headers({ 'Authorization': token, 'Content-Type': 'application/json; charset=utf-8' });
    let jsonPatient = JSON.stringify(patient);
    return this.http.post(apiUrl + '/api/patient', jsonPatient, { headers: headers })
                    .map((resp:Response) => resp.json())
                    .catch((error:any) => {
                        if(error.status === 401){
                            return Observable.throw(401);
                        }
                        return Observable.throw(error);
                    });
  }
}
