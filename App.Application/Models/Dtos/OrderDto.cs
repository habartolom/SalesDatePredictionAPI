using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Models.Dtos
{
	public class OrderDto
	{
		public int CustomerId { get; set; }
		public int EmployeeId { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime RequiredDate { get; set; }
		public decimal Freight { get; set; }
		public ShipDto Ship { get; set; } = new ShipDto();
		public ProductDto Product { get; set; } = new ProductDto();
	}
}
