using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.StoreProcedures
{
	public partial class SpCustomerOrder
	{
		public int OrderId { get; set; }
		public DateTime RequiredDate { get; set; }
		public DateTime? ShippedDate { get; set; }
		public string ShipName { get; set; } = null!;
		public string ShipAddress { get; set; } = null!;
		public string ShipCity { get; set; } = null!;
	}
}
