import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl = 'http://localhost:5000/api/auth/';
  jwtHelper = new JwtHelperService();
  decodeToken: any;

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http
    .post(`${this.baseUrl}Login`, model)
    .pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodeToken = this.jwtHelper.decodeToken(user.token);
          sessionStorage.setItem('username', this.decodeToken.unique_name);
        }
      })
      );
    }
    loggedIn(): boolean {
      const token = localStorage.getItem('token');
      return this.jwtHelper.isTokenExpired(token);
    }
    register(model: any) {
      return this.http.post(`${this.baseUrl}Register`, model);
    }
  }
