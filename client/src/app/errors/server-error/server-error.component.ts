import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.scss']
})
export class ServerErrorComponent implements OnInit {
  public error: any;

  constructor(private router: Router) {
    //We have to do this inside the constructor.
    //The ngOnInit is "too late" according to the instructor as it is already gone.
    const nav = this.router.getCurrentNavigation();
    this.error = nav?.extras?.state?.['error'];
    //This is using the 'error' from const navExtras: NavigationExtras = {state: {error: error}}; in error.interceptor.ts
   }

  ngOnInit(): void {
  }

}
