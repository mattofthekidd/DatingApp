import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  // @Input() usersFromHomeComponent: any; //this grabs an input from our parent component via html

  @Output() cancelRegister = new EventEmitter(); //sends data to the parent via html
  model: any = {};

  constructor(private accountService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  public register(): void {
    this.accountService.register(this.model).subscribe({
      next: () => {
        this.cancel();
      },
      error: e => {
        if(!!e.error?.errors) {
          this.toastr.error(e.error.errors.Password)
          this.toastr.error(e.error.errors.Username)
        }
        else {
          this.toastr.error(e.error)
        }
        console.log(e)
      }
    })
  }
  public cancel(): void {
    this.cancelRegister.emit(false);
  }

}
