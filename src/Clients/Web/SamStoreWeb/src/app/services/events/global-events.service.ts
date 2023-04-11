import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({ providedIn: "root" })
export class GlobalEventsService {
  public userLoggedIn: Subject<void> = new Subject<void>();
}
