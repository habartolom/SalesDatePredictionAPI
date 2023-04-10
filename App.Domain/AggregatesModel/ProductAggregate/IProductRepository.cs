using App.Domain.RepositoryBaseContracts;

namespace App.Domain.AggregatesModel.ProductAggregate
{
	public interface IProductRepository<TEntity> : IBaseCrudRepository<TEntity> where TEntity : class
	{
		IEnumerable<Product> GetAllProducts();
	}
}
