import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
@Injectable()
export class RouterService {
  constructor(private router: Router) {}
  routeToDashboard() {
    console.log('way to router');
    this.router.navigate(['dashboard']);
  }
  routeToLogin() {
    this.router.navigate(['login']);
  }
}
