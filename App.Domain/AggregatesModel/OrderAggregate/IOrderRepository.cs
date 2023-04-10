using App.Domain.AggregatesModel.CustomerAggregate;
using App.Domain.RepositoryBaseContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AggregatesModel.OrderAggregate
{
	public interface IOrderRepository<TEntity> : IBaseCrudRepository<TEntity> where TEntity : class
	{
		IEnumerable<CustomerOrder> GetOrdersByCustomer(out int orderId, int customerId, int sortColumn, string orderingDirection, int pageNumber, int pageSize);
		int AddOrder(OrderDetail orderDetail);
	}
}
