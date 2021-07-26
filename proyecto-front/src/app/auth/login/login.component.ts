import { Credentials } from './../models/credentials.interface';
import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  constructor(
    private authService:AuthService,
    private fb: FormBuilder,
		private router: Router
    ){ }

  ngOnInit(): void {
    this.form = this.fb.group({
			email: ['miriam.caceres@gmail.com', [Validators.required, Validators.email]],
			password: ['sg456844', [Validators.required]],
		});
  }

  get email() {
		return this.form.get('email');
	}

	get password() {
		return this.form.get('password');
	}

  submit(){
    const credentials:Credentials = this.form.value
    this.authService.postLogin(credentials).subscribe((response) => {
      console.log(response);
      this.router.navigate(['/Dashboard']);
    })
  }
}
