using App.Application.Models.Contracts;
using App.Application.Models.Dtos;
using App.Application.Models.Enums;
using App.Domain.AggregatesModel.CustomerAggregate;
using App.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Orders
{
    public interface IOrderService
    {
		TypedResponseContract<OrderDetail> AddOrder(OrderDto order);
		PagedResponseContract<List<CustomerOrder>> GetOrdersByCustomer(int customerId, int sortColumn, OrderDirectionEnum orderingDirection, int pageNumber, int pageSize);
	}
}
