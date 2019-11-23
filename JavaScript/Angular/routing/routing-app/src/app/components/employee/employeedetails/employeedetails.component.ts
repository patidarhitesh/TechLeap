import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { EmployeeService } from '../../../employee.service';

@Component({
  selector: 'app-employeedetails',
  templateUrl: './employeedetails.component.html',
  styleUrls: ['./employeedetails.component.css']
})
export class EmployeedetailsComponent implements OnInit {
  employee: any;
  constructor(
    private route: ActivatedRoute,
    private empSerrvice: EmployeeService
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const id = +params.get('id');
      this.empSerrvice
        .getEmployeeById(id)
        .subscribe(res => (this.employee = res));
      this.empSerrvice.getEmployeeById(id).subscribe(
        res => {
          if (res.status === 200) {
            this.employee = res.body;
          }
        },
        error => {
          if (error.status === 404) {
            alert("This employee ID doesn't exist.");
          } else if (error.status === 500) {
            alert('Some server issue. please try again later.');
          }
        }
      );
    });
  }
}
