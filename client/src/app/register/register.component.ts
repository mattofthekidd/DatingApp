import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  @Input() usersFromHomeComponent: any; //this grabs an input from our parent component via html
  @Output() cancelRegister = new EventEmitter(); //sends data to the parent
  model: any = {};
  constructor() { }

  ngOnInit(): void {
  }

  public register(): void {
    console.log(this.model);
  }
  public cancel(): void {
    this.cancelRegister.emit(false);
  }

}
