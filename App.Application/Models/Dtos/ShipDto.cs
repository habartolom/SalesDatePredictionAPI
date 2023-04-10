using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Models.Dtos
{
	public class ShipDto
	{
		public int ShipperId { get; set; }
		public string ShipName { get; set; } = null!;
		public string ShipAddress { get; set; } = null!;
		public string ShipCity { get; set; } = null!;
		public string ShipCountry { get; set; } = null!;
	}
}
