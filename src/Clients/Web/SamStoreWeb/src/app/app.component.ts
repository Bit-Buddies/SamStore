import { Component } from '@angular/core';
import { provideEnvironmentNgxMask, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  providers: [ provideNgxMask() ]
})
export class AppComponent {}
