using App.Domain.AggregatesModel.OrderAggregate;

namespace App.Infrastructure.Database.Entities
{
	public partial class EmployeeEntity
	{
		public int Empid { get; set; }

		public string Lastname { get; set; } = null!;

		public string Firstname { get; set; } = null!;

		public string Title { get; set; } = null!;

		public string Titleofcourtesy { get; set; } = null!;

		public DateTime Birthdate { get; set; }

		public DateTime Hiredate { get; set; }

		public string Address { get; set; } = null!;

		public string City { get; set; } = null!;

		public string? Region { get; set; }

		public string? Postalcode { get; set; }

		public string Country { get; set; } = null!;

		public string Phone { get; set; } = null!;

		public int? Mgrid { get; set; }

		public virtual ICollection<EmployeeEntity> InverseMgr { get; } = new List<EmployeeEntity>();

		public virtual EmployeeEntity? Mgr { get; set; }

		public virtual ICollection<OrderEntity> Orders { get; } = new List<OrderEntity>();
	}
}
