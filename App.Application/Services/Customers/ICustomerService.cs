using App.Application.Models.Contracts;
using App.Application.Models.Dtos;
using App.Application.Models.Enums;
using App.Domain.AggregatesModel.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Customers
{
	public interface ICustomerService
	{
		PagedResponseContract<List<CustomerNextPredictedOrder>> GetNextOrderPredictions(string customerName, int sortColumn, OrderDirectionEnum orderingDirection, int pageNumber, int pageSize);
	}
}
