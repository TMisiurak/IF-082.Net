import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { AppointmentCredentials } from '../_shared/models/AppointmentCredentials';
import {appointmentUrl} from '../../shared/_shared/settings/Urls';

@Injectable()
export class AppointmentService {
    constructor(private http: HttpClient) { }
    getAppointments() {
        return this.http.get(appointmentUrl);
    }
    createAppointment(credentials: AppointmentCredentials) {
        return this.http.post(appointmentUrl, credentials);
    }

    updateAppointment(credentials: AppointmentCredentials) {
        return this.http.put(appointmentUrl, credentials);
    }

    deleteAppointment(id: number) {
        return this.http.delete(appointmentUrl + '/' + id);
    }
}

