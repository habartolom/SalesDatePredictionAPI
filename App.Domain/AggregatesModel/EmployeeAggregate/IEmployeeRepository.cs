using App.Domain.RepositoryBaseContracts;

namespace App.Domain.AggregatesModel.EmployeeAggregate
{
	public interface IEmployeeRepository<TEntity> : IBaseCrudRepository<TEntity> where TEntity : class
	{
		IEnumerable<Employee> GetAllEmployees();
	}
}
