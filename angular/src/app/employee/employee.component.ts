import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { EmployeeService, EmployeeDto, genderOptions, GenderMapping, departmentOptions, DepartmentMapping, titleOptions, TitleMapping } from '@proxy/employees';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class EmployeeComponent implements OnInit {
  employee = { items: [], totalCount: 0 } as PagedResultDto<EmployeeDto>;

  selectedEmployee = {} as EmployeeDto; // declare selectedEmployee

  form: FormGroup;

  genders = genderOptions;

  titles = titleOptions;

  departments = departmentOptions;

  isModalOpen = false;

  getGenderString(value: number): string {
    return GenderMapping[value];
  }

  getDepartmentString(value: number): string {
    return DepartmentMapping[value];
  }

  getTitleString(value: number): string {
    return TitleMapping[value];
  }

  constructor(
    public readonly list: ListService,
    private employeeService: EmployeeService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) {}

  ngOnInit() {
    const employeeStreamCreator = (query) => this.employeeService.getList(query);

    this.list.hookToQuery(employeeStreamCreator).subscribe((response) => {
      this.employee = response;
    });
  }

  createEmployee() {
    this.selectedEmployee = {} as EmployeeDto; // reset the selected employee
    this.buildForm();
    this.isModalOpen = true;
  }

  editEmployee(id: string) {
    this.employeeService.get(id).subscribe((employee) => {
      this.selectedEmployee = employee;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.employeeService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      firstName: [this.selectedEmployee.firstName || '', Validators.required],
      lastName : [this.selectedEmployee.lastName || '', Validators.required],
      gender: [this.selectedEmployee.gender, Validators.required],
      department : [this.selectedEmployee.department, Validators.required],
      title: [this.selectedEmployee.title, Validators.required],
    });
  }

  // change the save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedEmployee.id
      ? this.employeeService.update(this.selectedEmployee.id, this.form.value)
      : this.employeeService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
}