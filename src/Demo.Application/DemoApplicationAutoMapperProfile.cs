using AutoMapper;
using Demo.Employees;

namespace Demo;

public class DemoApplicationAutoMapperProfile : Profile
{
    public DemoApplicationAutoMapperProfile()
    {
        CreateMap<Employee, EmployeeDto>();
        CreateMap<CreateUpdateEmployeeDto, Employee>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
