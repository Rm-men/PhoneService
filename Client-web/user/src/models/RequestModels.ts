export interface Answer {
  status: boolean;
  answer: any;
  error: number | null;
  errorText: string | null;
}
export interface RegistrationModel {
  family: string;
  name: string;
  patronymic: string;
  phone: string;
  email: string;
  clpassword: string;
}

export interface LoginModel {
  email: string;
  password: string;
}
