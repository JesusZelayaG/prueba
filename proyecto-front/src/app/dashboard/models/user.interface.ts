export interface User {
  id_user: number;
  first_name: string;
  second_name: string;
  last_name: string;
  second_last_name: string;
  user_email: string;
  user_password: string;
  user_type: string;
}
export interface UserPost {
  FirstName: string;
  SecondName: string;
  LastName: string;
  SecondLastName: string;
  Email: string;
  Password: string;
  UserType: string;
}
export interface UserUp {
  IdUser: number;
  FirstName: string;
  SecondName: string;
  LastName: string;
  SecondLastName: string;
  Email: string;
  Password: string;
  UserType: string;
}