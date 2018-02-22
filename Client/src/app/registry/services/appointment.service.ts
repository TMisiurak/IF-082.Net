import { Injectable } from '@angular/core';
import { Http, Response, Headers, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Appointment } from '../shared/Appointment';
import {apiUrl} from '../../shared/helpers/settings/Urls';

@Injectable()
export class AppointmentService {
    constructor(private http: Http) { }

    getAppointments(token: string) {
        const headers = new Headers({ 'Authorization': token });
        return this.http.get(apiUrl + '/api/appointment/', { headers: headers })
        .map((resp: Response) => resp.json())
        .catch((error: any) => {
            if (error.status === 401) {
                return Observable.throw(401);
            }
            return Observable.throw(error);
        });
    }

    makeAppointment(token: string, appointment: any) {
        const headers = new Headers({ 'Authorization': token, 'Content-Type': 'application/json; charset=utf-8'});
        const jsonApp = JSON.stringify(appointment);
        return this.http.post(apiUrl + '/api/appointment/', jsonApp, { headers: headers })
                        .map((resp: Response) => {
                            if (resp.status === 200) {
                                return resp.json();
                            }
                        })
                        .catch((error: any) => {
                            if (error.status === 400) {
                                return Observable.throw(400);
                            }
                            return Observable.throw(error);
                        });
    }
}

