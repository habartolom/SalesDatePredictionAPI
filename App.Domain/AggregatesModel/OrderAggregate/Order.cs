using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AggregatesModel.OrderAggregate
{
	public class Order
	{
		public int OrderId { get; set; }
		public int CustomerId { get; set; }
		public int EmployeeId { get; set; }
		public int ShipperId { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime RequiredDate { get; set; }
		public DateTime ShippedDate { get; set; }
		public decimal Freight { get; set; }
		public string ShipName { get; set; } = null!;
		public string ShipAddress { get; set; } = null!;
		public string ShipCity { get; set; } = null!;
		public string ShipCountry { get; set; } = null!;

	}
}
