using App.Application.Models.Contracts;
using App.Application.Models.Dtos;
using App.Application.Models.Enums;
using App.Domain.AggregatesModel.CustomerAggregate;
using App.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Customers
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository<CustomerEntity> _customerRepository;
		public CustomerService(ICustomerRepository<CustomerEntity> customerRepository)
		{
			_customerRepository = customerRepository;
		}
		public PagedResponseContract<List<CustomerNextPredictedOrder>> GetNextOrderPredictions(string customerName, int sortColumn, OrderDirectionEnum orderingDirection, int pageNumber, int pageSize)
		{
			PagedResponseContract<List<CustomerNextPredictedOrder>> response = new PagedResponseContract<List<CustomerNextPredictedOrder>>();
			int totalRows = 0;
			string orderDirection = orderingDirection == OrderDirectionEnum.Ascending ? "ASC" : "DESC";
			
			response.Data = _customerRepository.GetCustomerNextPredictedOrders(out totalRows, customerName, sortColumn, orderDirection, pageNumber, pageSize).ToList();
			response.TotalCount = totalRows;
			response.PageNumber = pageNumber;
			response.PageSize = pageSize;
			return response;
		}
	}
}
