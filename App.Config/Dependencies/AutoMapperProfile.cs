using App.Application.Models.Dtos;
using App.Domain.AggregatesModel.CustomerAggregate;
using App.Domain.AggregatesModel.EmployeeAggregate;
using App.Domain.AggregatesModel.OrderAggregate;
using App.Domain.AggregatesModel.ProductAggregate;
using App.Domain.AggregatesModel.ShipperAggregate;
using App.Infrastructure.Database.StoreProcedures;
using AutoMapper;

namespace App.Config.Dependencies
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<CustomerNextPredictedOrder, SpPredictedOrderDate>()
				.ReverseMap();

			CreateMap<CustomerOrder, SpCustomerOrder>()
				.ReverseMap();

			CreateMap<Employee, SpEmployee>()
				.ReverseMap();

			CreateMap<Product, SpProduct>()
				.ReverseMap();

			CreateMap<Shipper, SpShipper>()
				.ReverseMap();

			//CreateMap<OrderDto, OrderDetail>()
			//	.ForMember(dest => dest.Order.CustomerId, src => src.MapFrom(x => x.CustomerId))
			//	.ForMember(dest => dest.Order.EmployeeId, src => src.MapFrom(x => x.EmployeeId))
			//	.ForMember(dest => dest.Order.Freight, src => src.MapFrom(x => x.Freight))
			//	.ForMember(dest => dest.Order.OrderDate, src => src.MapFrom(x => x.OrderDate))
			//	.ForMember(dest => dest.Order.RequiredDate, src => src.MapFrom(x => x.RequiredDate))
			//	.ForMember(dest => dest.Order.ShipperId, src => src.MapFrom(x => x.Ship.ShipperId))
			//	.ForMember(dest => dest.Order.ShipName, src => src.MapFrom(x => x.Ship.ShipName))
			//	.ForMember(dest => dest.Order.ShipAddress, src => src.MapFrom(x => x.Ship.ShipAddress))
			//	.ForMember(dest => dest.Order.ShipCity, src => src.MapFrom(x => x.Ship.ShipCity))
			//	.ForMember(dest => dest.Order.ShipCountry, src => src.MapFrom(x => x.Ship.ShipCountry))
			//	.ForMember(dest => dest.Detail.ProductId, src => src.MapFrom(x => x.Product.ProductId))
			//	.ForMember(dest => dest.Detail.UnitPrice, src => src.MapFrom(x => x.Product.Unitprice))
			//	.ForMember(dest => dest.Detail.Quantity, src => src.MapFrom(x => x.Product.Quantity))
			//	.ForMember(dest => dest.Detail.Discount, src => src.MapFrom(x => x.Product.Discount))
			//	.ReverseMap();

			CreateMap<OrderDto, OrderDetail>()
				.ForMember(dest => dest.Order, opt => opt.MapFrom(src => new Order
				{
					CustomerId = src.CustomerId,
					EmployeeId = src.EmployeeId,
					ShipperId =  src.Ship.ShipperId,
					OrderDate = src.OrderDate,
					RequiredDate = src.RequiredDate,
					Freight = src.Freight,
					ShipName = src.Ship.ShipName,
					ShipAddress = src.Ship.ShipAddress,
					ShipCity = src.Ship.ShipCity,
					ShipCountry = src.Ship.ShipCountry,
				}))
				.ForMember(dest => dest.Detail, opt => opt.MapFrom(src => new Detail
				{
					ProductId = src.Product.ProductId,
					UnitPrice = src.Product.Unitprice,
					Quantity = src.Product.Quantity,
					Discount = src.Product.Discount
				}))
				.ReverseMap();
		}
	}
}
