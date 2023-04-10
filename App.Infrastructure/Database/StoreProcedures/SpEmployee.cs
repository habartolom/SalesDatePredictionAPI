using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.StoreProcedures
{
	public partial class SpEmployee
	{
		public int EmployeeId { get; set; }
		public string Fullname { get; set; } = null!;
	}
}
