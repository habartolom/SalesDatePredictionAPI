using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AggregatesModel.OrderAggregate
{
	public class OrderDetail
	{
		public Order Order { get; set; } = new Order();
		public Detail Detail { get; set; } = new Detail();
	}
}
