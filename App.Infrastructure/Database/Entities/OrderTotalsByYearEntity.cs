using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.Entities
{
	public partial class OrderTotalsByYearEntity
	{
		public int? Orderyear { get; set; }

		public int? Qty { get; set; }
	}
}
