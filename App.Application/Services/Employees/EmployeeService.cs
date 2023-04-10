using App.Application.Models.Contracts;
using App.Domain.AggregatesModel.EmployeeAggregate;
using App.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Employees
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository<EmployeeEntity> _employeeRepository;

		public EmployeeService(IEmployeeRepository<EmployeeEntity> employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public TypedResponseContract<List<Employee>> GetAllEmployees()
		{
			TypedResponseContract<List<Employee>> response = new TypedResponseContract<List<Employee>>();
			response.Data = _employeeRepository.GetAllEmployees().ToList();
			return response;
		}
	}
}
