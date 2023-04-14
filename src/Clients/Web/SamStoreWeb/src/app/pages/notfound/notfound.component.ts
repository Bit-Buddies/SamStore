import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-notfound',
  templateUrl: './notfound.component.html',
  styleUrls: ['./notfound.component.scss']
})
export class NotfoundComponent {
  constructor(private _router: Router) { }
  public onButtonHomePressed(){
    this._router.navigate(["/home"])
  }
}
