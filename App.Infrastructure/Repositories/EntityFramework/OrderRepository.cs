using App.Domain.AggregatesModel.CustomerAggregate;
using App.Domain.AggregatesModel.OrderAggregate;
using App.Infrastructure.Database.Context;
using App.Infrastructure.Database.Entities;
using App.Infrastructure.Database.StoreProcedures;
using App.Infrastructure.Repositories.EntityFramework.Base;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.EntityFramework
{
	public class OrderRepository : BaseCrudRepository<OrderEntity>, IOrderRepository<OrderEntity>
	{
		private readonly IMapper _mapper;
		public ApplicationContext Context
		{
			get
			{
				return (ApplicationContext)_Database;
			}
		}

		public OrderRepository(ApplicationContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public int AddOrder(OrderDetail orderDetail)
		{
			
			var orderIdParameter = new SqlParameter("@orderId", SqlDbType.Int) { Direction = ParameterDirection.Output };

			Context.Database.ExecuteSqlRaw(StoreProcedures.AddOrderWithProduct,
				new SqlParameter("@customerId", orderDetail.Order.CustomerId),
				new SqlParameter("@employeeId", orderDetail.Order.EmployeeId),
				new SqlParameter("@orderDate", orderDetail.Order.OrderDate),
				new SqlParameter("@requiredDate", orderDetail.Order.RequiredDate),
				new SqlParameter("@shipperId", orderDetail.Order.ShipperId),
				new SqlParameter("@freight", orderDetail.Order.Freight),
				new SqlParameter("@shipName", orderDetail.Order.ShipName),
				new SqlParameter("@shipAddress", orderDetail.Order.ShipAddress),
				new SqlParameter("@shipCity", orderDetail.Order.ShipCity),
				new SqlParameter("@shipCountry", orderDetail.Order.ShipCountry),
				new SqlParameter("@productId", orderDetail.Detail.ProductId),
				new SqlParameter("@unitPrice", orderDetail.Detail.UnitPrice),
				new SqlParameter("@quantity", orderDetail.Detail.Quantity),
				new SqlParameter("@discount", orderDetail.Detail.Discount),
				orderIdParameter
			);

			int orderId = (int)orderIdParameter.Value;
			return orderId;
		}

		public IEnumerable<CustomerOrder> GetOrdersByCustomer(out int totalRows, int customerId, int sortColumn, string orderingDirection, int pageNumber, int pageSize)
		{
			var totalParameter = new SqlParameter("@total", SqlDbType.Int) { Direction = ParameterDirection.Output };

			var result = Context.SpCustomerOrders
				.FromSqlRaw(StoreProcedures.GetOrdersByCustomer,
					new SqlParameter("@customerId", customerId),
					new SqlParameter("@sortColumn", sortColumn),
					new SqlParameter("@orderingDirection", orderingDirection),
					new SqlParameter("@pageNumber", pageNumber),
					new SqlParameter("@pageSize", pageSize),
					totalParameter
				)
				.ToList();

			totalRows = (int) totalParameter.Value;
			return _mapper.Map<IEnumerable<CustomerOrder>>(result);
		}
	}
}
