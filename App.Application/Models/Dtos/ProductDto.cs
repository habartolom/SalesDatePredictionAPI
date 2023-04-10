using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Models.Dtos
{
	public class ProductDto
	{
		public int ProductId { get; set; }
		public decimal Unitprice { get; set; }
		public short Quantity { get; set; }
		public decimal Discount { get; set; }
	}
}
