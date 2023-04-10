using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.StoreProcedures
{
	public partial class SpShipper
	{
		public int ShipperId { get; set; }
		public string CompanyName { get; set; } = null!;
	}
}
