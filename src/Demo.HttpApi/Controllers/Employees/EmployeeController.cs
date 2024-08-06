using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Demo.Employees;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Demo.Controllers.Employees
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Employee")]
    [Route("api/app/employees")]

    public class EmployeeController : AbpController
    {
        protected IEmployeeAppService _employeesAppService;

        public EmployeeController(IEmployeeAppService employeesAppService)
        {
            _employeesAppService = employeesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<EmployeeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _employeesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<EmployeeDto> GetAsync(Guid id)
        {
            return _employeesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<EmployeeDto> CreateAsync(CreateUpdateEmployeeDto input)
        {
            return _employeesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<EmployeeDto> UpdateAsync(Guid id, CreateUpdateEmployeeDto input)
        {
            return _employeesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _employeesAppService.DeleteAsync(id);
        }
    }
}