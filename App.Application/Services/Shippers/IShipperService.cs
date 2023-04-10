using App.Application.Models.Contracts;
using App.Domain.AggregatesModel.ShipperAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Shippers
{
	public interface IShipperService
	{
		TypedResponseContract<List<Shipper>> GetAllShippers();
	}
}
