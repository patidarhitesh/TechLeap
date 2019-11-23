import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable()
export class AuthenticationService {
  constructor(private httpClient: HttpClient) {}
  authenticateUser(data) {
    return this.httpClient.post('http://localhost:3000/auth/v1/', data);
  }
  setBearerToken(token) {
    localStorage.setItem('bearerToken', token);
  }
  getBearerToken() {
    return localStorage.getItem('bearerToken');
  }
  isUserAuthenticated(token){}
}
//: Promise<boolean> 