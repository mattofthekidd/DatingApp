import { Component, OnDestroy, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, Subscription, of } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit, OnDestroy {

  // of() tells the compiler that this is an 
  // Observable of type null
  // currentUser$: Observable<User | null> = of(null)

  public model: any = {username: '', password: ''};
  public username: string = "";
  private subs: Subscription[] = [];
  constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) { }

  ngOnDestroy():void  {
    this.subs.forEach(s => s.unsubscribe());
  }

  ngOnInit(): void {
    
    this.subs.push( 
      this.accountService.currentUser$.subscribe({
        next: res => this.username = !res?.username ? "" : res.username,
        error: e => console.log(e)
      })
    )

  }


  public login(): void {
      // this.model.username = this.model.username.trim(); //did this so I can be sloppy
    //we don't need to worry about unsubscribing from this
    //because it is an http request and they resolve
    //when they resolve they are automatically unsubed
      this.accountService.login(this.model).subscribe({
        next: () => this.router.navigateByUrl('/members'),
        error: e => {
          this.toastr.error(e.error)
          console.log("error: ", e)
        }
      });
      this.model = {username: '', password: ''};
    
  }
  public logout(): void {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
