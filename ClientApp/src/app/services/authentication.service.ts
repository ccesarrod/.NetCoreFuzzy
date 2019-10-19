import { Injectable, Inject,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { Subject, BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService implements OnInit{
 
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) { 
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  ngOnInit() {
   // debugger;
   // this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
   // this.currentUser = this.currentUserSubject.asObservable();
  }

  

  login(username: string, password: string) {
    debugger;
    this.logout();
    if (!localStorage.getItem('currentUser')) {
      return this.http.post<any>(`${environment.apiUrl}account/login`, { userName: username, password: password })
        .pipe(map(user => {
          // login successful if there's a jwt token in the response
          if (user) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.currentUserSubject.next(user);
          }
          return user;
        }));
    }
  }


  public get currentUserValue() {
    return this.currentUserSubject.value;
  }
  public get authenticatedUser():Observable<User> {
   return  this.currentUser;
  }

  logout() {
      
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);  
  }

  register(user: User) {
    return this.http.post<any>(`${environment.apiUrl}account/register`, user);
  }
}
