import { Component } from '@angular/core';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss'],
})
export class ToolbarComponent {
  public logado: boolean = false;

  logar() {
    this.logado = true;
  }

  deslogar() {
    this.logado = false;
  }
}
