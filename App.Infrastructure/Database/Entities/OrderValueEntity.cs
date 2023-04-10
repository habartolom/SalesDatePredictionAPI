using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.Entities
{
	public partial class OrderValueEntity
	{
		public int Orderid { get; set; }

		public int? Custid { get; set; }

		public int Empid { get; set; }

		public int Shipperid { get; set; }

		public DateTime Orderdate { get; set; }

		public decimal? Val { get; set; }
	}
}
