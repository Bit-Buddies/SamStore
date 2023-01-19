export interface ResponseApiError {
  title: string;
  status: number;
  errors: Errors;
}

export interface Errors {
  Mensagens: string[];
}
