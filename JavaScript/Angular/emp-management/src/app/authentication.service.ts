import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';
import { environment } from '../environments/environment';
import { Observable, pipe } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  isLoggedIn = false;
  userEmail: string;
  userfname: string;
  userlname: string;
  baseurl = environment.baseurl;
  constructor(private http: HttpClient) {}
  registerUser(user: User) {
    return this.http.post(this.baseurl, user);
  }

  login(userid: string, password: string): Observable<User> {
    return this.http.get<User[]>(this.baseurl).pipe(
      map(data => {
        console.log(data);
        let num = 0;
        if (
          data.some(user => user.email === userid && user.password === password)
        ) {
          this.isLoggedIn = true;
          for (num = 0; num < data.length; num++) {
            if (data[num].email == userid && data[num].password == password) {
              this.userEmail = data[num].email;
              this.userfname = data[num].fname;
              this.userlname = data[num].lname;
              localStorage.setItem('email', this.userEmail.toString());
              localStorage.setItem('fname', this.userfname.toString());
              localStorage.setItem('lname', this.userlname.toString());
              return data[num];
            }
          }
        } else {
          this.isLoggedIn = false;
          alert('User does not exist');
        }
      })
    );
  }

  isAdmin() {
    return localStorage.getItem('admin');
  }
  isAuthenticated() {
    return this.isLoggedIn;
  }
}
