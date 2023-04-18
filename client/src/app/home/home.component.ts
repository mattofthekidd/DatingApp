import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public registerMode = false;
  public users: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getUsers();
  }

  public registerToggle() {
    this.registerMode = !this.registerMode;
  }

  private getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: res => this.users = res,
      error: error => console.log(error),
      complete: () => console.log('Request completed'),
    });
  }

  public cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

}
