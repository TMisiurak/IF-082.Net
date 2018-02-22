import { Component, OnInit } from '@angular/core';
import {AppointmentService} from '../../_services/appointment.service';
import { Appointment } from '../../_shared/models/Appointment';
import { Router } from '@angular/router';
import { CheckTokenService } from '../../../core/_services/check-token.service';

@Component({
    selector: 'app-appointment',
    templateUrl: './appointment.component.html',
    styleUrls: ['./appointment.component.scss']
  })

export class AppointmentsComponent implements OnInit {
    appointment: Appointment = new Appointment();
    appointments: Appointment[];
    tableMode = true;

    constructor(private appoService: AppointmentService, private router: Router
        , private checkTokenService: CheckTokenService) { }

    ngOnInit() {
        this.getAppointments();
    }

    getAppointments() {
        this.appoService.getAppointments(this.checkTokenService.authorizationToken)
            .subscribe((data: Appointment[]) => this.appointments = data);
    }

    save() {
        this.appoService.makeAppointment(this.checkTokenService.authorizationToken, this.appointment)
        .subscribe((data: Appointment) => this.appointments.push(data));
        this.cancel();
    }

    cancel() {
        this.appointment = new Appointment();
        this.tableMode = true;
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }
}
