import { ProductsComponent } from './products/products.component';
import { OverviewComponent } from './overview/overview.component';
import { LayoutComponent } from './layout/layout.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    component:LayoutComponent,
    children:[
      {
        path: '',
        redirectTo: 'overview',
        pathMatch: 'full'
      },
      {
        path:'overview',
        component:OverviewComponent
      },{
        path:'product',
        component:ProductsComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
