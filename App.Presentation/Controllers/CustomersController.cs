using App.Application.Models.Contracts;
using App.Application.Models.Enums;
using App.Application.Services.Customers;
using App.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.AspNetCore.Mvc;

namespace App.Presentation.Controllers
{
	/// <summary>
	/// Customer Controller
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="customerService"></param>
		public CustomersController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		/// <summary>
		/// This endpoint gets a list of customers with their possible next order date
		/// </summary>
		/// <param name="pageNumber"></param>
		/// <param name="pageSize"></param>
		/// <returns>A paged response with a list of customers with their possible next order date</returns>
		[HttpGet("OrderPredictions")]
		public PagedResponseContract<List<CustomerNextPredictedOrder>> GetNextOrderPredictions(string? customerName, int sortColumn = 0, OrderDirectionEnum orderingDirection = OrderDirectionEnum.Ascending, int pageNumber = 1, int pageSize = 10)
		{
			return _customerService.GetNextOrderPredictions(customerName ?? "", sortColumn, orderingDirection, pageNumber, pageSize);
		}
	}
}
