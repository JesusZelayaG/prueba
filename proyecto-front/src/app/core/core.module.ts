import { JwtInterceptor } from './jwtinterceptor.service';
import { CommonModule } from "@angular/common";
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { NgModule } from "@angular/core";

@NgModule({
    declarations: [],
    imports: [
      CommonModule,
    ],
    providers: [
      {
        provide: HTTP_INTERCEPTORS, 
        useClass: JwtInterceptor, 
        multi: true
      },
    ]
  })
  export class CoreModule { }
  