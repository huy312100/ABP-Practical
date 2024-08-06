import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap'; // add this line

@NgModule({
  declarations: [EmployeeComponent],
  imports: [
    EmployeeRoutingModule,
    SharedModule,
    NgbDatepickerModule, // add this line
  ]
})
export class EmployeeModule { }
