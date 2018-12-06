import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { Subject, BehaviorSubject, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  profile$: Subject<any> = new BehaviorSubject<any>({});

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  emit(value: any) {
    this.profile$.next(value);
  }

  login(username: string, password: string) {
    return this.http.post<any>(`${this.baseUrl}api/account/login`, {email: username, password: password })
      .pipe(map(user => {
        // login successful if there's a jwt token in the response
        if (user) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', user);
          this.emit( user );
        }
        return user;
      }));
  }

  get authenticatedUser(): BehaviorSubject<any> {
    return this.profile$ as BehaviorSubject<any>;
  }

  logout() {
      
    localStorage.removeItem('currentUser');
    this.emit(null);
  }
  register(user: User) {
    return this.http.post<any>(`${this.baseUrl}api/account/register`, user);
  }
}
