import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../../services/appointment.service';
import { AppointmentCredentials } from '../../shared/models/AppointmentCredentials';

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
