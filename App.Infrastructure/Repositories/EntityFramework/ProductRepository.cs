using App.Domain.AggregatesModel.ProductAggregate;
using App.Domain.AggregatesModel.ShipperAggregate;
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
	public class ProductRepository : BaseCrudRepository<ProductEntity>, IProductRepository<ProductEntity>
	{
		private readonly IMapper _mapper;
		public ApplicationContext Context
		{
			get
			{
				return (ApplicationContext)_Database;
			}
		}

		public ProductRepository(ApplicationContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
		}

		public IEnumerable<Product> GetAllProducts()
		{
			var result = Context.SpProducts.FromSqlRaw(StoreProcedures.GetAllProducts).ToList();
			return _mapper.Map<IEnumerable<Product>>(result);
		}
	}
}
