using App.Application.Models.Contracts;
using App.Domain.AggregatesModel.EmployeeAggregate;
using App.Domain.AggregatesModel.ShipperAggregate;
using App.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Shippers
{
	public class ShipperService : IShipperService
	{
		private readonly IShipperRepository<ShipperEntity> _shipperRepository;
		public ShipperService(IShipperRepository<ShipperEntity> shipperRepository)
		{
			_shipperRepository = shipperRepository;
		}
		public TypedResponseContract<List<Shipper>> GetAllShippers()
		{
			TypedResponseContract<List<Shipper>> response = new TypedResponseContract<List<Shipper>>();
			response.Data = _shipperRepository.GetAllShippers().ToList();
			return response;
		}
	}
}
