using App.Application.Models.Contracts;
using App.Domain.AggregatesModel.ProductAggregate;

namespace App.Application.Services.Products
{
	public interface IProductService
	{
		TypedResponseContract<List<Product>> GetAllProducts();
	}
}
