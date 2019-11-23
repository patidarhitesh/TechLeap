import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
@Injectable()
export class RouterService {
  constructor (private router: Router,
               private location: Location) { }
 
  routeToLogin() {
    this.router.navigate(['login']);
  }

  routeBack() {
    this.location.back();
  }
  routeToProd() {
    this.router.navigate(['product']);
  }

}
