import { FormGroup, FormBuilder } from '@angular/forms';
import { OverviewService } from './../overview/service/overview.service';
import { Products, ProductIn } from './../models/products.interface';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  form:FormGroup;
  list:Products[];
  constructor(
    private overviewService:OverviewService,
    private formBuilder:FormBuilder
    ){
  }

  ngOnInit(): void {
    this.loadData();
    this.form = this.formBuilder.group({
			IdProduct: 'asd54',
			ProductName: 'Semillas',
      ProductDesc: 'Semillas de almendra',
      ProductPrice: '0.26',
      ProductCategory: 'AlimentosS'
		})
  }
  get IdProduct(){
    return this.form.get('IdProduct');
  }
  get ProductName(){
    return this.form.get('ProductName');
  }
  get ProductDesc(){
    return this.form.get('ProductDesc');
  }
  get ProductPrice(){
    return this.form.get('ProductPrice');
  }
  get ProductCategory(){
    return this.form.get('ProductCategory')
  }

  loadData(){
    this.overviewService.getAllProduct().subscribe((data)=>{
      this.list = data;
      console.log(data);
    })
  }
  submit(){
    const product:ProductIn = this.form.value;
    console.log(product)
    this.overviewService.addNewProduct(product).subscribe((response)=>{
      console.log(response);
    })
  }
  openForEdit(product:Products){
    this.form = this.formBuilder.group({
      IdProduct: product.id_product,
			ProductName: product.product_name,
      ProductDesc: product.product_desc,
      ProductPrice: product.product_price,
      ProductCategory: product.category
    })
  }
  update(){
    const product:ProductIn = this.form.value
    console.log(product)
    this.overviewService.modifyNewProduct(product).subscribe((response)=>{
      console.log(response);
    })
  }
  delete(id:string){
    this.overviewService.deleteProduct(id).subscribe();
  }
}
