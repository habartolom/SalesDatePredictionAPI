using App.Domain.AggregatesModel.CustomerAggregate;
using App.Infrastructure.Database.Context;
using App.Infrastructure.Database.Entities;
using App.Infrastructure.Database.StoreProcedures;
using App.Infrastructure.Repositories.EntityFramework.Base;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.EntityFramework
{
	public class CustomerRepository : BaseCrudRepository<CustomerEntity>, ICustomerRepository<CustomerEntity>
	{
		private readonly IMapper _mapper;
		public ApplicationContext Context
		{
			get
			{
				return (ApplicationContext)_Database;
			}
		}

		public CustomerRepository(ApplicationContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public IEnumerable<CustomerNextPredictedOrder> GetCustomerNextPredictedOrders(out int totalRows, string customerName, int sortColumn, string orderingDirection, int pageNumber, int pageSize)
		{
			var customerNameParameter = new SqlParameter("@customerName", customerName);
			var sortColumnParameter = new SqlParameter("@sortColumn", sortColumn);
			var orderingDirectionParameter = new SqlParameter("@orderingDirection", orderingDirection);
			var pageNumberParameter = new SqlParameter("@pageNumber", pageNumber);
			var pageSizeParameter = new SqlParameter("@pageSize", pageSize);
			var totalParameter = new SqlParameter("@total", SqlDbType.Int) { Direction = ParameterDirection.Output };

			var result = Context.SpPredictedOrderDates
				.FromSqlRaw(StoreProcedures.GetNextPredictedOrderStoreProcedure, customerNameParameter, sortColumnParameter, orderingDirectionParameter, pageNumberParameter, pageSizeParameter, totalParameter)
				.ToList();

			totalRows = (int)totalParameter.Value;
			return _mapper.Map<IEnumerable<CustomerNextPredictedOrder>>(result);
		}
	}
}
