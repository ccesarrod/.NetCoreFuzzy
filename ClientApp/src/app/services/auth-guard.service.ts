import { Injectable } from '@angular/core';
import { Router, CanActivate, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { AuthenticationService } from './authentication.service';
import { map } from 'rxjs/operators';
import { of, Observable } from 'rxjs';

@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(public auth: AuthenticationService, public router: Router) { }


  canActivate(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | Observable<boolean> {

    return this.auth.authenticatedUser.pipe(

        map(currentUser => {
          let url: string = state.url;
          if (currentUser.user)
            return true;
          else {
            this.router.navigate(['/login']);
            return false;
          }
      })

    );      
    
  }
}
