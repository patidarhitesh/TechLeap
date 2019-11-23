import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { AuthenticationService } from '../../authentication.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  signupForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private authservice: AuthenticationService
  ) {
    this.signupForm = this.fb.group(
      {
        fname: [
          '',
          Validators.compose([
            Validators.required,
            Validators.maxLength(15),
            Validators.minLength(1)
          ])
        ],
        lname: ['', [Validators.required, Validators.maxLength(19)]],
        Emailid: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required],
        confirmpassword: ['', Validators.required]
      },
      { validators: this.passwordMatcher('password', 'confirmpassword') }
    );
  }

  // registerForm = new FormGroup({
  //   fname: new FormControl(''),
  //   lname: new FormControl(''),
  //   contact: new FormControl(''),
  //   password: new FormControl('')
  // });

  register() {
    console.log(this.signupForm.value);
    let user = {
      fname: this.signupForm.value.fname,
      lname: this.signupForm.value.lname,
      email: this.signupForm.value.Emailid,
      password: this.signupForm.value.password
    };
    this.authservice.registerUser(user).subscribe(
      r => {
        alert('User Registered successfully!!!');
      },
      error => {
        alert('Some error occured.');
      }
    );
  }

  passwordMatcher(controlName: string, matchingControlName: string) {
    return (formgroup: FormGroup) => {
      const control = formgroup.controls[controlName];
      const matchingControl = formgroup.controls[matchingControlName];

      // set error on matchingControl if validation fails
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ passwordMatcher: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }

  ngOnInit() {}
}
