using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.StoreProcedures
{
	public class SpProduct
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; } = null!;
	}
}
