import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse } from '@angular/common/http';
import { Subject, Observable, throwError } from 'rxjs';
import { tap, map, catchError } from 'rxjs/operators';
import { Employee } from './components/employee/employee';
// import { HttpClient } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  sub1: any;
  // employees = [
  //   { id: 101, name: 'Harish', location: 'Delhi', technology: 'Java' },
  //   { id: 102, name: 'Ganesh', location: 'Mumbai', technology: 'DevOps' },
  //   { id: 103, name: 'Kamles', location: 'Bhopal', technology: 'Spring' },
  //   { id: 104, name: 'Rohit', location: 'Kanpur', technology: '.NET' }
  // ];
  constructor(private http: HttpClient) {}

  baseUrl = 'http://localhost:3000/Employees';
  employeeAdded: Subject<any> = new Subject();
  employeeDel: Subject<any> = new Subject();
  emp: any = [];
  getEmployees(): Observable<HttpResponse<Employee>> {
    return this.http.get<Employee>(this.baseUrl, { observe: 'response' });
  }
  getEmployeeById(id: number): Observable<any> {
    return this.http
      .get(`${this.baseUrl}\\${id}`, { observe: 'response' })
      .pipe(catchError(err => throwError(err)));
  }
  addEmployee(employee: { name: any; location: any; technology: any }) {
    return this.http.post(this.baseUrl, employee).pipe(
      map(res => {
        console.log('map');

        // tslint:disable-next-line: no-string-literal
        res['name'] = res['name'].toUpperCase();
        return res;
      }),
      tap(x => this.employeeAdded.next(x))
    );
  }

  delEmployee(id) {
    console.log(`${this.baseUrl}/${id}`);

    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
