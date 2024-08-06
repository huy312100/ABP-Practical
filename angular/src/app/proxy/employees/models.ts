import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';
import type { Gender, Department, Title } from './employee.enum';

export interface AuthorLookupDto extends EntityDto<string> {
  name?: string;
}

export interface EmployeeDto extends AuditedEntityDto<string> {
  firstName: string;
  lastName: string;
  gender: Gender;
  department: Department;
  title: Title;
}

export interface CreateUpdateEmployeeDto {
  firstName: string;
  lastName: string;
  gender: Gender;
  department: Department;
  title: Title;
}
