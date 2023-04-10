using App.Domain.AggregatesModel.EmployeeAggregate;
using App.Domain.RepositoryBaseContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AggregatesModel.ShipperAggregate
{
	public interface IShipperRepository<TEntity> : IBaseCrudRepository<TEntity> where TEntity : class
	{
		IEnumerable<Shipper> GetAllShippers();
	}
}
