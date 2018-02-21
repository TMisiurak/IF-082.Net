import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { AppointmentCredentials } from '../_shared/models/AppointmentCredentials';
import {apiUrl} from '../../shared/_shared/settings/Urls';

@Injectable()
export class AppointmentService {
    constructor(private http: HttpClient) { }
    getAppointments() {
        return this.http.get(apiUrl + "/api/appointment");
    }
    createAppointment(credentials: AppointmentCredentials) {
        return this.http.post(apiUrl + "/api/appointment", credentials);
    }

    updateAppointment(credentials: AppointmentCredentials) {
        return this.http.put(apiUrl + "/api/appointment", credentials);
    }

    deleteAppointment(id: number) {
        return this.http.delete(apiUrl + "/api/appointment/" + id);
    }
}

