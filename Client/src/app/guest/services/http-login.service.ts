import { Injectable } from '@angular/core';
import { Http, Response, Headers, URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { tokenUrl } from '../../shared/helpers/settings/Urls';

@Injectable()
export class HttpLoginService {
	
    constructor(private http: Http){ }   

    login(credentials: string){
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' });         
        return this.http.post(tokenUrl + '/connect/token', credentials, { headers: headers })
                        .map((resp:Response) => {
                            if(resp.status === 200){
                                return resp.json();
                            }
                        })
                        .catch((error:any) => {
                            if(error.status === 400){
                                return Observable.throw(400);
                            }
                            return Observable.throw(error);
                        }); 
    }
}
