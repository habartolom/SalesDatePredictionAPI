using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AggregatesModel.OrderAggregate
{
	public class Detail
	{
		public int ProductId { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Quantity { get; set; }
		public decimal Discount { get; set; }
	}
}
