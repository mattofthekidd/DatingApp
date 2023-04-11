import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Dating App';

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    
    this.setCurrentUser();
  }


  private setCurrentUser() {
    //the ! turns off Typescript safety (overriding strict mode).
    // Essentially we are telling the compiler that we know best
    // const user: User = JSON.parse(localStorage.getItem('user')!);

    //alternatively we can ignore the parsing and check if the string we get
    // is a string or null
    const userString = localStorage.getItem('user');
    if(!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }


}
