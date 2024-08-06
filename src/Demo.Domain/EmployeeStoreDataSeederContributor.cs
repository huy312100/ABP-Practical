using System;
using System.Threading.Tasks;
using Demo.Emp;
using Demo.Employees;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Demo;

public class DemoDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Employee, Guid> _employeeRepository;

    public DemoDataSeederContributor(IRepository<Employee, Guid> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _employeeRepository.GetCountAsync() <= 0)
        {
            await _employeeRepository.InsertAsync(
                new Employee
                {
                    FirstName = "Huy",
                    LastName = "Nguyen",
                    Gender = Gender.Male,
                    Department = Department.IT,
                    Title = Title.Specialist
                },
                autoSave: true
            );

            await _employeeRepository.InsertAsync(
                new Employee
                {
                    FirstName = "Trang",
                    LastName = "Do",
                    Gender = Gender.Female,
                    Department = Department.Marketing,
                    Title = Title.Manager
                },
                autoSave: true
            );
        }
    }
}