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

    constructor(private appoService: AppointmentService) { }

    ngOnInit() {
    }

}
