import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  // @Input() usersFromHomeComponent: any; //this grabs an input from our parent component via html

  @Output() cancelRegister = new EventEmitter(); //sends data to the parent via html
  model: any = {};

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  public register(): void {
    this.accountService.register(this.model).subscribe({
      next: () => {
        this.cancel();
      },
      error: e => console.log(e)
    })
  }
  public cancel(): void {
    this.cancelRegister.emit(false);
  }

}
