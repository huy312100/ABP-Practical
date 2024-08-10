import { mapEnumToOptions } from '@abp/ng.core';

export enum Gender {
  Female = 0,
  Male = 1,
}

export const GenderMapping = {
  [Gender.Male]: 'Male',
  [Gender.Female]: 'Female'
};

export enum Department {
  Unknown = 0,
  IT = 1,
  Finance = 2,
  HR = 3,
  Marketing = 4,
  Sales = 5
}

export const DepartmentMapping = {
  [Department.Unknown]: 'Unknown',
  [Department.IT]: 'IT',
  [Department.Finance]: 'Finance',
  [Department.HR]: 'Human resources',
  [Department.Marketing]: 'Marketing',
  [Department.Sales]: 'Sales'
};

export enum Title {
  Unknown = 0,
  Specialist = 1,
  Manager = 2,
}

export const TitleMapping = {
  [Title.Unknown]: 'Unknown',
  [Title.Specialist]: 'Specialist',
  [Title.Manager]: 'Manager'
};

export const genderOptions = mapEnumToOptions(Gender);
export const departmentOptions = mapEnumToOptions(Department);
export const titleOptions = mapEnumToOptions(Title);