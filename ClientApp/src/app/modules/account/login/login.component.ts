import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthenticationService } from '../../../services/authentication.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string = '';


  constructor(
    private formBuilder: FormBuilder,
    private loginService: AuthenticationService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.loginService.login(this.loginForm.controls.email.value, this.loginForm.controls.password.value)
      .subscribe(
        data => {
          if (data) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
          //  localStorage.setItem('currentUser', JSON.stringify(data));
            this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
            this.router.navigate([this.returnUrl]);
          }

        },
        error => {
          console.error(error);
          this.loading = false;
        });
  }

}
