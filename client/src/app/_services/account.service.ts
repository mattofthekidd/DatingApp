import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';

//decorator Injectable means it can be injected into our components or other services
@Injectable({
  //normally we'd need to put this service into the 'providers' in our app.module.
  //This "providedIn: 'root'" metadata means we don't need to anymore
  providedIn: 'root' 
})
export class AccountService {
  private baseUrl = 'https://localhost:5001/api/';
  private currentUserSource = new BehaviorSubject<User | null>(null); //can be a user or null, called a union type

  public currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  public login(model: any) {
    //by piping we can change the observable asit comes back from the API
    //piping occurs before subscription resolution. sec 5.55
    //map is an rxjs thingy
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((res: User) => {
        const user = res;
        if(user) {
          localStorage.setItem('user', JSON.stringify(user))
          this.currentUserSource.next(user);
        };
      })
    );
  }

  public setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  public logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
