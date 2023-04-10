using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AggregatesModel.EmployeeAggregate
{
	public class Employee
	{
		public int EmployeeId { get; set; }
		public string FullName { get; set; } = null!;
	}
}
