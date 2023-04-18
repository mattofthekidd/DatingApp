import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

//ng g _guards/auth

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  //will automatically subscribe and unsubscribe from Obersables
  constructor(private accountService: AccountService, private toastr: ToastrService) {}

  canActivate(): Observable<boolean> {
    //need to project the observable
    return this.accountService.currentUser$.pipe(
      map(user => {
        if(user) return true;
        else {
          this.toastr.error('User not authenticated');
          return false;
        }
      })
    );
  }
  
}
