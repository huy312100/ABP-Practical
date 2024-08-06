using System;
using Demo.Emp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.Employees;

public class Employee : AuditedAggregateRoot<Guid>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Gender Gender { get; set; }

    public Department Department { get; set; }

    public Title Title { get; set; }
}