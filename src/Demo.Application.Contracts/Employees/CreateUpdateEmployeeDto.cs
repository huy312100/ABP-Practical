using System;
using System.ComponentModel.DataAnnotations;
using Demo.Emp;

namespace Demo.Employees;

public class CreateUpdateEmployeeDto
{
    [Required]
    [StringLength(128)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(128)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public Gender? Gender { get; set; } = null;

    [Required]
    public Department Department { get; set; } = Department.Unknown;

    [Required]
    public Title Title { get; set; } = Title.Unknown;
}