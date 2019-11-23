import { Component, OnInit, OnDestroy } from '@angular/core';
import { EmployeeService } from '../../../employee.service';

import { Router } from '@angular/router';

@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.css']
})
export class EmployeelistComponent implements OnInit, OnDestroy {
  employees: any = [];
  sub1: any;
  sub2: any;
  sub3: any;
  constructor(private empservice: EmployeeService, private router: Router) {}

  ngOnInit() {
    this.getAllEmployees();
    this.sub1 = this.empservice.employeeAdded.subscribe(res =>
      this.employees.push(res)
    );
  }
  getAllEmployees() {
    this.sub2 = this.empservice.getEmployees().subscribe(resp => {
      console.log(resp);
      if (resp.status === 200) {
        this.employees = resp.body;
      }
    });
  }
  del(id) {
    this.sub3 = this.empservice.delEmployee(id).subscribe(response => {
      console.log(response);
    });

    this.employees = this.employees.filter(item => item.id !== id);
  }
  ngOnDestroy(): void {
    // Called once, before the instance is destroyed.
    // Add 'implements OnDestroy' to the class.
    this.sub1.unsubscribe();
    this.sub2.unsubscribe();
    this.sub3.unsubscribe();
  }
}
