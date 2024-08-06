using System;
using Volo.Abp.Application.Dtos;
using Demo.Emp;

namespace Demo.Employees;

public class EmployeeDto : AuditedEntityDto<Guid>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Gender Gender { get; set; }

    public Department Department { get; set; }

    public Title Title { get; set; }
}