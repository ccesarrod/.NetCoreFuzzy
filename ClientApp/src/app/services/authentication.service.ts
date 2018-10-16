import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../models/user';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  login(username: string, password: string) {
    return this.http.post<any>(`${this.baseUrl}api/account/login`, {email: username, password: password })
      .pipe(map(user => {
        // login successful if there's a jwt token in the response
        if (user && user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
        }

        return user;
      }));
  }


  register(user: User) {
    return this.http.post<any>(`${this.baseUrl}api/account/register`, user);
  }
}
