import { Component, OnInit } from '@angular/core';
import {AppointmentService} from '../../_services/appointment.service';
import { AppointmentCredentials } from '../../_shared/models/AppointmentCredentials';
import { DoctorCredentials } from '../../_shared/models/DoctorCredentials';
import { Router } from '@angular/router';
import { CheckTokenService } from '../../../core/_services/check-token.service';

@Component({
    selector: 'app-appointment',
    templateUrl: './appointment.component.html',
    styleUrls: ['./appointment.component.scss']
  })

export class AppointmentsComponent implements OnInit {
    appointment: AppointmentCredentials = new AppointmentCredentials();
    appointments: AppointmentCredentials[];
    doctor: DoctorCredentials = new DoctorCredentials;
    doctors: DoctorCredentials[];
    tableMode = true;

    constructor(private appoService: AppointmentService, private router: Router
        , private checkTokenService: CheckTokenService) { }

    ngOnInit() {
        this.getAppointments();
    }

    getAppointments() {
        this.appoService.getAppointments(this.checkTokenService.authorizationToken)
            .subscribe((data: AppointmentCredentials[]) => this.appointments = data);
    }

    getDoctors(id: number) {
        this.appoService.getDoctor(this.checkTokenService.authorizationToken, id)
            .subscribe((data: DoctorCredentials[]) => this.doctors = data);
    }

    save() {
        this.appoService.makeAppointment(this.checkTokenService.authorizationToken, this.appointment)
        .subscribe((data: AppointmentCredentials) => this.appointments.push(data));
        this.cancel();
    }

    cancel() {
        this.appointment = new AppointmentCredentials();
        this.tableMode = true;
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }
}
