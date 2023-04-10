using App.Application.Models.Contracts;
using App.Application.Services.Employees;
using App.Application.Services.Shippers;
using App.Domain.AggregatesModel.EmployeeAggregate;
using App.Domain.AggregatesModel.ShipperAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShippersController : ControllerBase
	{
		private readonly IShipperService _shipperService;

		public ShippersController(IShipperService shipperService)
		{
			_shipperService = shipperService;
		}

		[HttpGet("All")]
		public TypedResponseContract<List<Shipper>> GetAll()
		{
			return _shipperService.GetAllShippers();
		}
	}
}
