using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AggregatesModel.CustomerAggregate
{
	public class CustomerNextPredictedOrder
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; } = null!;
		public DateTime LastOrderDate { get; set; }
		public DateTime NextPredictedOrder { get; set; }
	}
}
