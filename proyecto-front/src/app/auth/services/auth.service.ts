import { Credentials, ApiResponse } from './../models/credentials.interface';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn = new BehaviorSubject<boolean>(false);
  baseUrl = environment.url;
  constructor(private http:HttpClient) { 
  }
  postLogin(credentials:Credentials){
    return this.http.post(this.baseUrl+"/Login",credentials)
    .pipe(map((data:ApiResponse) => {
      localStorage.setItem('token', data.Value.token)
      return data.Value
    }));
  }
}
