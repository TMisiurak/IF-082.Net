import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../../services/appointment.service';
import { Appointment } from '../../shared/models/Appointment';
import { CheckTokenService } from '../../../core/services/check-token.service';
import { Router } from '@angular/router';
import { GetScheduleService } from '../../../core/services/get-schedule.service';

@Component({
    selector: 'app-appointment',
    templateUrl: './appointment.component.html',
    styleUrls: ['./appointment.component.scss']
  })

export class AppointmentsComponent implements OnInit {
    appointment: Appointment = new Appointment();
    appointments: Appointment[];
    tableMode = true;

    constructor(private appoService: AppointmentService, private scheduleService: GetScheduleService, private router: Router
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

    getSchedule() {
        this.scheduleService.getSchedule(this.appointment.doctorId, this.checkTokenService.authorizationToken)
        .subscribe();
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }
}
