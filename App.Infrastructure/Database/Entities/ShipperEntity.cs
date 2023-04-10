using App.Domain.AggregatesModel.OrderAggregate;

namespace App.Infrastructure.Database.Entities
{
	public partial class ShipperEntity
	{
		public int Shipperid { get; set; }

		public string Companyname { get; set; } = null!;

		public string Phone { get; set; } = null!;

		public virtual ICollection<OrderEntity> Orders { get; } = new List<OrderEntity>();
	}
}
