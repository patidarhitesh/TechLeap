import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentication.service';
import { RouterService } from '../../services/router.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = new FormControl('', [Validators.required]);
  password = new FormControl('', [Validators.required]);
  public bearerToken: any;
  public submitMessage: string;
  constructor(
    private authService: AuthenticationService,
    private routerService: RouterService,
    private router: Router
  ) {}
  loginSubmit() {
    const user: any = {
      name: this.username.value,
      password: this.password.value
    };
    if (
      this.username.hasError('required') ||
      this.password.hasError('required')
    ) {
      this.submitMessage = 'Username and Password required';
    } else {
      this.authService.loginUser(user.username, user.password).subscribe(
        res => {
          console.log(res);

          this.router.navigateByUrl('/cart');
        },
        err => {
          if (err.status === 404) {
            this.submitMessage = err.message;
          } else {
            this.submitMessage = err.error.message;
          }
        }
      );
    }
  }
}
