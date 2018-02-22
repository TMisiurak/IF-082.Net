import { Injectable } from '@angular/core';
import { Http, Response, Headers, URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { apiUrl } from '../../shared/helpers/settings/Urls';

@Injectable()
export class GetUserService {
    
  constructor(private http: Http){ }

  getUser(id: number, token: string){        
      let headers = new Headers({ 'Authorization': token });
      return this.http.get(apiUrl + '/api/user/' + id, { headers: headers })
                      .map((resp:Response) => resp.json())
                      .catch((error:any) => {
                          if(error.status === 401){
                              return Observable.throw(401);
                          }
                          return Observable.throw(error);
                      }); 
  }
}
