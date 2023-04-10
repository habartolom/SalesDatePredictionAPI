using App.Domain.AggregatesModel.EmployeeAggregate;
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
	public class EmployeeRepository : BaseCrudRepository<EmployeeEntity>, IEmployeeRepository<EmployeeEntity>
	{
		private readonly IMapper _mapper;
		public ApplicationContext Context
		{
			get
			{
				return (ApplicationContext)_Database;
			}
		}

		public EmployeeRepository(ApplicationContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public IEnumerable<Employee> GetAllEmployees()
		{
			var result = Context.SpEmployees.FromSqlRaw(StoreProcedures.GetAllEmployees).ToList();
			return _mapper.Map<IEnumerable<Employee>>(result);
		}
	}
}
