import { User, UserPost, UserUp } from './../models/user.interface';
import { OverviewService } from './service/overview.service';
import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {

  form:FormGroup;

  constructor(
    private overviewService:OverviewService,
    private fb:FormBuilder
  ){
  }
  
  list?:User[];

  ngOnInit(): void {
    this.loadData();
    this.form = this.fb.group({
      IdUser:'',
      FirstName:'',
      SecondName:'',
      LastName:'',
      SecondLastName:'',
      Email:'',
      Password:'',
      UserType:''
    })
    
  }
  get FirstName(){
    return this.form.get('FirstName')
  }
  get SecondName(){
    return this.form.get('SecondName')
  }
  get LastName(){
    return this.form.get('LastName')
  }
  get SecondLastName(){
    return this.form.get('SecondLastName')
  }
  get Email(){
    return this.form.get('Email')
  }
  get Password(){
    return this.form.get('Password')
  }
  get UserType(){
    return this.form.get('UserType')
  }

  
  loadData(){
    this.overviewService.getAllUser().subscribe((data)=>{
      this.list = data;
      console.log(data);
    })
  }
  submit(){
    const user:UserPost = this.form.value
    this.overviewService.addNewUser(user).subscribe((data)=>{
    })
  }
  delete(id:number){
    this.overviewService.deleteUser(id).subscribe();
  }
  update(){
    const user:UserUp = this.form.value
      this.overviewService.modifyNewUser(user).subscribe((response)=>{
      })
    
  }
  sendForUpdate(user:User){
    this.form = this.fb.group({
      IdUser:user.id_user,
      FirstName:user.first_name,
      SecondName:user.second_name,
      LastName:user.last_name,
      SecondLastName:user.second_last_name,
      Email:user.user_email,
      Password:user.user_password,
      UserType:user.user_type
    })
  }
}
