import { Products, ProductIn } from './../../models/products.interface';
import { User, UserPost, UserUp } from './../../models/user.interface';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class OverviewService {
  baseUrl = environment.url;
  constructor(private http:HttpClient) { }
  getAllUser():Observable<User[]>{
    return this.http.get<User[]>(this.baseUrl+'/Users');
  }
  getAllProduct():Observable<Products[]>{
    return this.http.get<Products[]>(this.baseUrl+'/Product');
  }
  addNewProduct(product:ProductIn){
    return this.http.post(this.baseUrl+'/Product',product);
  }
  addNewUser(user:UserPost){
    return this.http.post(this.baseUrl+'/Users',user);
  }
  modifyNewProduct(product:ProductIn){
    return this.http.put(this.baseUrl+'/Product',product);
  }
  modifyNewUser(user:UserUp){
    return this.http.put(this.baseUrl+'/Users',user);
  }
  deleteUser(id:number){
    return this.http.delete(this.baseUrl+`/Users/${id}`);
  }
  deleteProduct(id:string){
    return this.http.delete(this.baseUrl+`/Product/${id}`);
  }
}
