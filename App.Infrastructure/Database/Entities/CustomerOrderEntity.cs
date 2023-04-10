using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.Entities
{
	public partial class CustomerOrderEntity
	{
		public int? Custid { get; set; }

		public DateTime? Ordermonth { get; set; }

		public int? Qty { get; set; }
	}
}
