import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-page-title-more',
  templateUrl: './page-title-more.component.html',
  styleUrls: ['./page-title-more.component.scss']
})
export class PageTitleMoreComponent {
  @Input() title: string = "";
  @Input() moreButtonDescription?: string;
  @Input() moreButtonActionCallback: Function = () : void => {};
}
