import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../user';
import { environment } from '../../environments/environment';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  baseurl = environment.baseurl;
  loginForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private auth: AuthenticationService,
    private http: HttpClient
  ) {
    this.loginForm = this.fb.group({
      Emailid: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      admin: [false]
    });
  }

  ngOnInit() {}
  login() {
    let userId = this.loginForm.controls['Emailid'].value;
    let password = this.loginForm.controls['password'].value;

    this.auth.login(userId, password).subscribe(res => {
      if (res.admin) {
        this.router.navigateByUrl('/admin');
      } else {
        this.router.navigateByUrl('/employees');
      }
    });
  }
}
