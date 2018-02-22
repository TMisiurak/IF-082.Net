import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.scss']
})
export class ContactsComponent implements OnInit {

  email = 'contact@clinicinc.com';
  phoneNumbers: any =
  [
    {phone: '1-800-555-1234', name: 'Reception'},
    {phone: '1-800-555-5555', name: 'USA helpline'},
    {phone: '1-800-555-1111', name: 'Other'}
  ];
  address: any =
  [
    {line: 'USA, CA'},
    {line: 'Palo-Alto'},
    {line: 'Big Medical Loop, 101'},
    {line: 'ClinicInc'}
  ];

  constructor() { }

  ngOnInit() {
  }

}
