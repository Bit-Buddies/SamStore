import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable({
	providedIn: "root",
})
export class NavbarService {
    public showNavbar$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);

    public show() {
        this.showNavbar$.next(true);
    }

    public hide() {
        this.showNavbar$.next(false);
    }
}