import { Component, OnInit } from '@angular/core';
import {AppointmentService} from '../../_services/appointment.service';
import { AppointmentCredentials } from '../../_shared/models/AppointmentCredentials';

@Component({
    selector: 'app-appointment',
    templateUrl: './appointment.component.html',
    styleUrls: ['./appointment.component.scss']
  })

export class AppointmentsComponent implements OnInit {
    appointment: AppointmentCredentials = new AppointmentCredentials();
    appointments: AppointmentCredentials[];
    tableMode: boolean = true;

    /*constructor(private appoService: AppointmentService) { }*/

    ngOnInit() {
       // this.loadAppointments();
    }
/*
    loadAppointments() {
        this.appoService.getAppointments()
            .subscribe((data: AppointmentCredentials[]) => this.appointments = data);
    }

    save() {
        if (this.appointment.id == null) {
            this.appoService.createAppointment(this.appointment)
                .subscribe((data: AppointmentCredentials) => this.appointment = data);
        } else {
            this.appoService.updateAppointment(this.appointment)
                .subscribe(data => this.loadAppointments);
        }
        this.cancel();
    }

    cancel() {
        this.appointment = new AppointmentCredentials();
        this.tableMode = true;
    }

    delete(appo: AppointmentCredentials) {
        this.appoService.deleteAppointment(appo.id)
            .subscribe(data => this.loadAppointments);
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }*/
}
