import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse } from '@angular/common/http';
import { Subject, Observable, throwError } from 'rxjs';
import { tap, map, catchError } from 'rxjs/operators';
import { Employee } from '../app/employee';
// import { HttpClient } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  sub1: any;

  constructor(private http: HttpClient) {}

  baseUrl = 'http://localhost:3000/users';
  employeeAdded: Subject<any> = new Subject();
  employeeDel: Subject<any> = new Subject();
  emp: any = [];
  getEmployees(): Observable<HttpResponse<Employee>> {
    return this.http.get<Employee>(this.baseUrl, { observe: 'response' });
  }
  // getEmployeeByEmail(email: string): Observable<any> {
  //   return this.http
  //     .get(this.baseUrl, { observe: 'response' })
  //     .pipe(map(data => {
  //       data.some(t=> t.email === email)
  //     }))
  //     .pipe(catchError(err => throwError(err)));
  // }
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
