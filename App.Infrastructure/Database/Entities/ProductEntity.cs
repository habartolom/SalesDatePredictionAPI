namespace App.Infrastructure.Database.Entities
{
	public partial class ProductEntity
	{
		public int Productid { get; set; }

		public string Productname { get; set; } = null!;

		public int Supplierid { get; set; }

		public int Categoryid { get; set; }

		public decimal Unitprice { get; set; }

		public bool Discontinued { get; set; }

		public virtual CategoryEntity Category { get; set; } = null!;

		public virtual ICollection<OrderDetailEntity> OrderDetails { get; } = new List<OrderDetailEntity>();

		public virtual SupplierEntity Supplier { get; set; } = null!;
	}
}
