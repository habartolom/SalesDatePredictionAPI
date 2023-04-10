using App.Application.Models.Contracts;
using App.Application.Models.Dtos;
using App.Application.Models.Enums;
using App.Domain.AggregatesModel.OrderAggregate;
using App.Infrastructure.Database.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Orders
{
	public class OrderService : IOrderService
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository<OrderEntity> _orderRepository;
		public OrderService(IMapper mapper, IOrderRepository<OrderEntity> orderRepository)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
		}

		public TypedResponseContract<OrderDetail> AddOrder(OrderDto order)
		{
			TypedResponseContract<OrderDetail> response = new TypedResponseContract<OrderDetail>();
			try
			{
				OrderDetail orderDetail = _mapper.Map<OrderDetail>(order);
				int orderId = _orderRepository.AddOrder(orderDetail);
				response.Data = orderDetail;
				response.Data.Order.OrderId = orderId;
			}
			catch (Exception ex)
			{
				response.Header.Code = HttpStatusCode.InternalServerError;
				response.Header.Message = ex.ToString();
			}
			return response;
		}

		public PagedResponseContract<List<CustomerOrder>> GetOrdersByCustomer(int customerId, int sortColumn, OrderDirectionEnum orderingDirection, int pageNumber, int pageSize)
		{
			PagedResponseContract<List<CustomerOrder>> response = new PagedResponseContract<List<CustomerOrder>>();
			try
			{
				int totalRows = 0;
				string orderDirection = orderingDirection == OrderDirectionEnum.Ascending ? "ASC" : "DESC";
				response.Data = _orderRepository.GetOrdersByCustomer(out totalRows, customerId, sortColumn, orderDirection, pageNumber, pageSize).ToList();
				response.TotalCount = totalRows;
				response.PageNumber = pageNumber;
				response.PageSize = pageSize;
			}
			catch (Exception ex)
			{
				response.Header.Code = HttpStatusCode.InternalServerError;
				response.Header.Message = ex.ToString();
			}
			return response;
		}
	}
}
