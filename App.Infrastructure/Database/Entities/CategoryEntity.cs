using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.Entities
{
	public partial class CategoryEntity
	{
		public int Categoryid { get; set; }

		public string Categoryname { get; set; } = null!;

		public string Description { get; set; } = null!;

		public virtual ICollection<ProductEntity> Products { get; } = new List<ProductEntity>();
	}
}
