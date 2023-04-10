using App.Domain.AggregatesModel.OrderAggregate;

namespace App.Infrastructure.Database.Entities
{
	public partial class OrderDetailEntity
	{
		public int Orderid { get; set; }

		public int Productid { get; set; }

		public decimal Unitprice { get; set; }

		public short Qty { get; set; }

		public decimal Discount { get; set; }

		public virtual OrderEntity Order { get; set; } = null!;

		public virtual ProductEntity Product { get; set; } = null!;
	}
}
