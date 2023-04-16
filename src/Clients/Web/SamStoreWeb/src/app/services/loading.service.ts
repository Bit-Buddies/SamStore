import { Subject } from "rxjs";
import { Injectable } from "@angular/core";

@Injectable({
	providedIn: "root",
})
export class LoadingService {
	private _isLoading: boolean = false;
	public onLoadingChange: Subject<boolean> = new Subject<boolean>();

	public setLoading(isLoading: boolean) {
		this._isLoading = isLoading;
		this.onLoadingChange.next(this._isLoading);
	}

	public isLoading(): boolean {
		return this._isLoading;
	}
}
