import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  isLoggedIn = false;
  baseurl = environment.baseurl;
  constructor(private http: HttpClient) {}
  registerUser(user: User) {
    return this.http.post(this.baseurl, user);
  }
  loginUser(userid: string, password: string): Observable<boolean> {
    return this.http.get<User[]>(this.baseurl).pipe(
      map(data => {
        if (
          data.some(user => user.email === userid && user.password ===password)
        ) {
          this.isLoggedIn = true;
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
