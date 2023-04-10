using App.Application.Models.Contracts;
using App.Domain.AggregatesModel.EmployeeAggregate;

namespace App.Application.Services.Employees
{
	public interface IEmployeeService
	{
		TypedResponseContract<List<Employee>> GetAllEmployees();
	}
}
