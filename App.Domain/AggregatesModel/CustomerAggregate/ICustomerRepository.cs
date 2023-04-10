using App.Domain.RepositoryBaseContracts;

namespace App.Domain.AggregatesModel.CustomerAggregate
{
    public interface ICustomerRepository<TEntity> : IBaseCrudRepository<TEntity> where TEntity : class
    {
		IEnumerable<CustomerNextPredictedOrder> GetCustomerNextPredictedOrders(out int totalRows, string customerName, int sortColumn, string orderingDirection, int pageNumber, int pageSize);
	}
}
