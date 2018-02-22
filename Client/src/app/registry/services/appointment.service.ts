import { Injectable } from '@angular/core';
import { Http, Response, Headers, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { AppointmentCredentials } from '../shared/models/AppointmentCredentials';
import {apiUrl} from '../../shared/helpers/settings/Urls';

@Injectable()
export class AppointmentService {
    constructor(private http: Http) { }

    getAppointments() {
        return this.http.get(apiUrl + 'api/appointment')
        .map((resp: Response) => resp.json())
        .catch((error: any) => {
            if (error.status === 401) {
                return Observable.throw(401);
            }
            return Observable.throw(error);
        });
    }
}

