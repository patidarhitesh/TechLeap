import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { User } from '../user';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
@Injectable()
export class AuthenticationService {
  isLoggedIn: any;
  baseurl = 'http://localhost:3000/users';
  constructor(private http: HttpClient) {}

  registerUser(user: User) {
    return this.http.post(this.baseurl, user);
  }
  loginUser(userid: string, password: string): Observable<boolean> {
    return this.http.get<User[]>(this.baseurl).pipe(
      map(data => {
        if (
          data.some(user => user.email === userid && user.password === password)
        ) {this.isLoggedIn = true;
          return true;
        } else {
          this.isLoggedIn = false;
          return false;
        }
      })
    );
  }
  isAuthenticated() {
    return this.isLoggedIn;
  }
}
