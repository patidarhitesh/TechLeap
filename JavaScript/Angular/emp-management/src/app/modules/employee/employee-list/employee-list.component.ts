import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { EmployeeService } from '../../../employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {


  fetchedEmail = localStorage.getItem('email');
  fetchedfname = localStorage.getItem('fname');
  fetchedlname = localStorage.getItem('lname');

  

  constructor() {}

  ngOnInit() {
    console.log(this.fetchedEmail);
    console.log(this.fetchedfname);
    console.log(this.fetchedlname);
  }
}
