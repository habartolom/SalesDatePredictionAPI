using App.Application.Models.Contracts;
using App.Application.Models.Dtos;
using App.Application.Models.Enums;
using App.Application.Services.Orders;
using App.Domain.AggregatesModel.OrderAggregate;
using Microsoft.AspNetCore.Mvc;

namespace App.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderService _orderService;
		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost("Add")]
		public TypedResponseContract<OrderDetail> AddOrder(OrderDto order)
		{
			return _orderService.AddOrder(order);
		}

		[HttpGet("Customer/{customerId}")]
		public PagedResponseContract<List<CustomerOrder>> GetOrdersByCustomer(int customerId, int sortColumn = 0, OrderDirectionEnum orderingDirection = OrderDirectionEnum.Ascending, int pageNumber = 1, int pageSize = 10)
		{
			return _orderService.GetOrdersByCustomer(customerId, sortColumn, orderingDirection, pageNumber, pageSize);
		}
	}
}
