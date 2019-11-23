import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { RouterService } from './services/router.service';
import { AuthenticationService } from './services/authentication.service';
@Injectable()
export class CanActivateRouteGuard implements CanActivate {
  constructor(
    private authService: AuthenticationService,
    private routeService: RouterService
  ) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {
    const prom = this.authService.isUserAuthenticated(
      this.authService.getBearerToken()
    );
    return prom.then(authenticated => {
      if (!authenticated) {
        this.routeService.routeToLogin();
      }
      console.log('authenticated');
      return authenticated;
    });
  }
}
