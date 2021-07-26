export interface Credentials{
    email:string;
    password:string
}
export interface ApiResponse {
  Value: Value;
  Formatters: any[];
  ContentTypes: any[];
  DeclaredType?: any;
  StatusCode: number;
}

export interface Value {
  token: string;
  expiration: string;
}