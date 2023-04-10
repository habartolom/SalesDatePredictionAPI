using App.Application.Models.Contracts;
using App.Application.Models.Enums;
using App.Application.Services.Employees;
using App.Domain.AggregatesModel.CustomerAggregate;
using App.Domain.AggregatesModel.EmployeeAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;

		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet("All")]
		public TypedResponseContract<List<Employee>> GetAll()
		{
			return _employeeService.GetAllEmployees();
		}
	}
}
