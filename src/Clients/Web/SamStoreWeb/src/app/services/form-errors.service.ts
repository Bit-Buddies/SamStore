import { Injectable } from "@angular/core";

export class FormErrorsService {
	public errors: string[] = [];

	public clearErrors() {
		this.errors = [];
	}

	public addError(error: string) {
		this.errors.push(error);
	}
}
