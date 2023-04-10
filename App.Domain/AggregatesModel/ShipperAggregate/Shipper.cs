using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AggregatesModel.ShipperAggregate
{
	public class Shipper
	{
		public int ShipperId { get; set; }
		public string CompanyName { get; set; } = null!;
	}
}
