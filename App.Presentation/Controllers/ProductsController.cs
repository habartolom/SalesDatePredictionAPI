using App.Application.Models.Contracts;
using App.Application.Services.Products;
using App.Application.Services.Shippers;
using App.Domain.AggregatesModel.ProductAggregate;
using App.Domain.AggregatesModel.ShipperAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Presentation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("All")]
		public TypedResponseContract<List<Product>> GetAll()
		{
			return _productService.GetAllProducts();
		}
	}
}
