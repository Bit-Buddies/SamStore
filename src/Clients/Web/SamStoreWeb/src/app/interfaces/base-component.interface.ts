import { Subject } from "rxjs";
import { OnDestroy } from "@angular/core";

export interface IBaseComponent extends OnDestroy {
    unsubscribeAll$: Subject<void>;
}