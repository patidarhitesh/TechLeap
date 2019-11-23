import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private auth: AuthenticationService
  ) {
    this.loginForm = this.fb.group({
      Emailid: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  ngOnInit() {}
  login() {
    let userId = this.loginForm.controls['Emailid'].value;
    let password = this.loginForm.controls['password'].value;
 
    this.auth.loginUser(userId, password).subscribe(res => {
     
      if (res == true) {
        this.router.navigateByUrl('/home');
      } else {
        console.log('login');
        alert('Invalid UserId or Password');
      }
    });
  }
}
