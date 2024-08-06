using System;
using Demo.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Demo.Employees;

public class EmployeeAppService :
    CrudAppService<
        Employee, //The Employee entity
        EmployeeDto, //Used to show employees
        Guid, //Primary key of the employee entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateEmployeeDto>, //Used to create/update a employee
    IEmployeeAppService //implement the IEmployeeAppService
{
    public EmployeeAppService(IRepository<Employee, Guid> repository)
        : base(repository)
    {
        GetPolicyName = DemoPermissions.Employees.Default;
        GetListPolicyName = DemoPermissions.Employees.Default;
        CreatePolicyName = DemoPermissions.Employees.Create;
        UpdatePolicyName = DemoPermissions.Employees.Edit;
        DeletePolicyName = DemoPermissions.Employees.Delete;
    }
}