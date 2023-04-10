using App.Application.Models.Contracts;
using App.Domain.AggregatesModel.ProductAggregate;
using App.Infrastructure.Database.Entities;

namespace App.Application.Services.Products
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository<ProductEntity> _productRepository;

		public ProductService(IProductRepository<ProductEntity> productRepository)
		{
			_productRepository = productRepository;
		}

		public TypedResponseContract<List<Product>> GetAllProducts()
		{
			TypedResponseContract<List<Product>> response = new TypedResponseContract<List<Product>>();
			response.Data = _productRepository.GetAllProducts().ToList();
			return response;
		}
	}
}
