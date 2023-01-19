import { EventEmitter, Injectable } from "@angular/core";

@Injectable()
export class GlobalEventsService {
  static userLoggedIn = new EventEmitter();
}
