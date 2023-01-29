import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";
import { cpf } from "cpf-cnpj-validator";

export function ValidateCPF(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (!value) return null;

    const isValid = cpf.isValid(value);

    return isValid ? null : { cpf: true };
  };
}
