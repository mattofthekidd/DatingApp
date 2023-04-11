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
  users: any;

  constructor(private http: HttpClient, private accountService: AccountService) {}
  //removed async and await because he isn't using it yet and I assume he will later.
  ngOnInit(): void {
    this.getUsers();
    this.setCurrentUser();
  }

  private getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: x => this.users = x,
      error: error => console.log(error),
      complete: () => console.log('Request completed'),
    });
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
