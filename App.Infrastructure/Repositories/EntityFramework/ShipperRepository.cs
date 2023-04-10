using App.Domain.AggregatesModel.EmployeeAggregate;
using App.Domain.AggregatesModel.ShipperAggregate;
using App.Domain.RepositoryBaseContracts;
using App.Infrastructure.Database.Context;
using App.Infrastructure.Database.Entities;
using App.Infrastructure.Database.StoreProcedures;
using App.Infrastructure.Repositories.EntityFramework.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.EntityFramework
{
    public class ShipperRepository : BaseCrudRepository<ShipperEntity>, IShipperRepository<ShipperEntity>
	{
		private readonly IMapper _mapper;
		public ApplicationContext Context
		{
			get
			{
				return (ApplicationContext)_Database;
			}
		}

		public ShipperRepository(ApplicationContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public IEnumerable<Shipper> GetAllShippers()
		{
			var result = Context.SpShippers.FromSqlRaw(StoreProcedures.GetAllShippers).ToList();
			return _mapper.Map<IEnumerable<Shipper>>(result);
		}
	}
}
