import { Component } from '@angular/core';
import { provideEnvironmentNgxMask, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-root',
  template: `
    <app-toolbar id="navbar" [validateShowNavbar]="true"></app-toolbar>
    <router-outlet></router-outlet>
  `,
  styleUrls: [ './app.component.scss'],
  providers: [ provideNgxMask() ]
})
export class AppComponent {}
