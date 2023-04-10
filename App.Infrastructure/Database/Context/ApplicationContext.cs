using App.Domain.AggregatesModel.CustomerAggregate;
using App.Domain.AggregatesModel.OrderAggregate;
using App.Infrastructure.Database.Entities;
using App.Infrastructure.Database.StoreProcedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.Context
{
	
	public class ApplicationContext : DbContext
	{
        public IConfiguration _configuration { get; }

		#region DbEntities
		public virtual DbSet<CategoryEntity> Categories { get; set; }
		public virtual DbSet<CustomerOrderEntity> CustomerOrders { get; set; }
		public virtual DbSet<CustomerEntity> Customers { get; set; }
		public virtual DbSet<EmployeeEntity> Employees { get; set; }
		public virtual DbSet<OrderEntity> Orders { get; set; }
		public virtual DbSet<OrderDetailEntity> OrderDetails { get; set; }
		public virtual DbSet<OrderTotalsByYearEntity> OrderTotalsByYears { get; set; }
		public virtual DbSet<OrderValueEntity> OrderValues { get; set; }
		public virtual DbSet<ProductEntity> Products { get; set; }
		public virtual DbSet<ShipperEntity> Shippers { get; set; }
		public virtual DbSet<SupplierEntity> Suppliers { get; set; }

		#endregion DbEntities

		#region DbStoreProcedures
		public virtual DbSet<SpCustomerOrder> SpCustomerOrders { get; set; }
		public virtual DbSet<SpEmployee> SpEmployees { get; set; }
		public virtual DbSet<SpPredictedOrderDate> SpPredictedOrderDates { get; set; }
		public virtual DbSet<SpProduct> SpProducts { get; set; }
		public virtual DbSet<SpShipper> SpShippers { get; set; }

		#endregion DbStoreProcedures
		
		public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
		{
			_configuration = configuration;
		}

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("App.Presentation"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CategoryEntity>(entity =>
			{
				entity.HasKey(e => e.Categoryid);
				entity.ToTable("Categories", "Production");
				entity.HasIndex(e => e.Categoryname, "categoryname");
				entity.Property(e => e.Categoryid).HasColumnName("categoryid");
				entity.Property(e => e.Categoryname).HasMaxLength(15).HasColumnName("categoryname");
				entity.Property(e => e.Description).HasMaxLength(200).HasColumnName("description");
			});

			modelBuilder.Entity<CustomerOrderEntity>(entity =>
			{
				entity.HasNoKey().ToView("CustOrders", "Sales");
				entity.Property(e => e.Custid).HasColumnName("custid");
				entity.Property(e => e.Ordermonth).HasColumnType("datetime").HasColumnName("ordermonth");
				entity.Property(e => e.Qty).HasColumnName("qty");
			});

			modelBuilder.Entity<CustomerEntity>(entity =>
			{
				entity.HasKey(e => e.Custid);
				entity.ToTable("Customers", "Sales");
				entity.HasIndex(e => e.City, "idx_nc_city");
				entity.HasIndex(e => e.Companyname, "idx_nc_companyname");
				entity.HasIndex(e => e.Postalcode, "idx_nc_postalcode");
				entity.HasIndex(e => e.Region, "idx_nc_region");
				entity.Property(e => e.Custid).HasColumnName("custid");
				entity.Property(e => e.Address).HasMaxLength(60).HasColumnName("address");
				entity.Property(e => e.City).HasMaxLength(15).HasColumnName("city");
				entity.Property(e => e.Companyname).HasMaxLength(40).HasColumnName("companyname");
				entity.Property(e => e.Contactname).HasMaxLength(30).HasColumnName("contactname");
				entity.Property(e => e.Contacttitle).HasMaxLength(30).HasColumnName("contacttitle");
				entity.Property(e => e.Country).HasMaxLength(15).HasColumnName("country");
				entity.Property(e => e.Fax).HasMaxLength(24).HasColumnName("fax");
				entity.Property(e => e.Phone).HasMaxLength(24).HasColumnName("phone");
				entity.Property(e => e.Postalcode).HasMaxLength(10).HasColumnName("postalcode");
				entity.Property(e => e.Region).HasMaxLength(15).HasColumnName("region");
			});

			modelBuilder.Entity<EmployeeEntity>(entity =>
			{
				entity.HasKey(e => e.Empid);
				entity.ToTable("Employees", "HR");
				entity.HasIndex(e => e.Lastname, "idx_nc_lastname");
				entity.HasIndex(e => e.Postalcode, "idx_nc_postalcode");
				entity.Property(e => e.Empid).HasColumnName("empid");
				entity.Property(e => e.Address).HasMaxLength(60).HasColumnName("address");
				entity.Property(e => e.Birthdate).HasColumnType("datetime").HasColumnName("birthdate");
				entity.Property(e => e.City).HasMaxLength(15).HasColumnName("city");
				entity.Property(e => e.Country).HasMaxLength(15).HasColumnName("country");
				entity.Property(e => e.Firstname).HasMaxLength(10).HasColumnName("firstname");
				entity.Property(e => e.Hiredate).HasColumnType("datetime").HasColumnName("hiredate");
				entity.Property(e => e.Lastname).HasMaxLength(20).HasColumnName("lastname");
				entity.Property(e => e.Mgrid).HasColumnName("mgrid");
				entity.Property(e => e.Phone).HasMaxLength(24).HasColumnName("phone");
				entity.Property(e => e.Postalcode).HasMaxLength(10).HasColumnName("postalcode");
				entity.Property(e => e.Region).HasMaxLength(15).HasColumnName("region");
				entity.Property(e => e.Title).HasMaxLength(30).HasColumnName("title");
				entity.Property(e => e.Titleofcourtesy).HasMaxLength(25).HasColumnName("titleofcourtesy");
				entity.HasOne(d => d.Mgr).WithMany(p => p.InverseMgr).HasForeignKey(d => d.Mgrid).HasConstraintName("FK_Employees_Employees");
			});

			modelBuilder.Entity<OrderEntity>(entity =>
			{
				entity.HasKey(e => e.Orderid);
				entity.ToTable("Orders", "Sales");
				entity.HasIndex(e => e.Custid, "idx_nc_custid");
				entity.HasIndex(e => e.Empid, "idx_nc_empid");
				entity.HasIndex(e => e.Orderdate, "idx_nc_orderdate");
				entity.HasIndex(e => e.Shippeddate, "idx_nc_shippeddate");
				entity.HasIndex(e => e.Shipperid, "idx_nc_shipperid");
				entity.HasIndex(e => e.Shippostalcode, "idx_nc_shippostalcode");
				entity.Property(e => e.Orderid).HasColumnName("orderid");
				entity.Property(e => e.Custid).HasColumnName("custid");
				entity.Property(e => e.Empid).HasColumnName("empid");
				entity.Property(e => e.Freight).HasColumnType("money").HasColumnName("freight");
				entity.Property(e => e.Orderdate).HasColumnType("datetime").HasColumnName("orderdate");
				entity.Property(e => e.Requireddate).HasColumnType("datetime").HasColumnName("requireddate");
				entity.Property(e => e.Shipaddress).HasMaxLength(60).HasColumnName("shipaddress");
				entity.Property(e => e.Shipcity).HasMaxLength(15).HasColumnName("shipcity");
				entity.Property(e => e.Shipcountry).HasMaxLength(15).HasColumnName("shipcountry");
				entity.Property(e => e.Shipname).HasMaxLength(40).HasColumnName("shipname");
				entity.Property(e => e.Shippeddate).HasColumnType("datetime").HasColumnName("shippeddate");
				entity.Property(e => e.Shipperid).HasColumnName("shipperid");
				entity.Property(e => e.Shippostalcode).HasMaxLength(10).HasColumnName("shippostalcode");
				entity.Property(e => e.Shipregion).HasMaxLength(15).HasColumnName("shipregion");
				entity.HasOne(d => d.Cust).WithMany(p => p.Orders).HasForeignKey(d => d.Custid).HasConstraintName("FK_Orders_Customers");
				entity.HasOne(d => d.Emp).WithMany(p => p.Orders).HasForeignKey(d => d.Empid).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Orders_Employees");
				entity.HasOne(d => d.Shipper).WithMany(p => p.Orders).HasForeignKey(d => d.Shipperid).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Orders_Shippers");
			});

			modelBuilder.Entity<OrderDetailEntity>(entity =>
			{
				entity.HasKey(e => new { e.Orderid, e.Productid });
				entity.ToTable("OrderDetails", "Sales");
				entity.HasIndex(e => e.Orderid, "idx_nc_orderid");
				entity.HasIndex(e => e.Productid, "idx_nc_productid");
				entity.Property(e => e.Orderid).HasColumnName("orderid");
				entity.Property(e => e.Productid).HasColumnName("productid");
				entity.Property(e => e.Discount).HasColumnType("numeric(4, 3)").HasColumnName("discount");
				entity.Property(e => e.Qty).HasDefaultValueSql("((1))").HasColumnName("qty");
				entity.Property(e => e.Unitprice).HasColumnType("money").HasColumnName("unitprice");
				entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails).HasForeignKey(d => d.Orderid).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderDetails_Orders");
				entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails).HasForeignKey(d => d.Productid).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderDetails_Products");
			});

			modelBuilder.Entity<OrderTotalsByYearEntity>(entity =>
			{
				entity.HasNoKey().ToView("OrderTotalsByYear", "Sales");
				entity.Property(e => e.Orderyear).HasColumnName("orderyear");
				entity.Property(e => e.Qty).HasColumnName("qty");
			});

			modelBuilder.Entity<OrderValueEntity>(entity =>
			{
				entity.HasNoKey().ToView("OrderValues", "Sales");
				entity.Property(e => e.Custid).HasColumnName("custid");
				entity.Property(e => e.Empid).HasColumnName("empid");
				entity.Property(e => e.Orderdate).HasColumnType("datetime").HasColumnName("orderdate");
				entity.Property(e => e.Orderid).HasColumnName("orderid");
				entity.Property(e => e.Shipperid).HasColumnName("shipperid");
				entity.Property(e => e.Val).HasColumnType("numeric(12, 2)").HasColumnName("val");
			});

			modelBuilder.Entity<ProductEntity>(entity =>
			{
				entity.HasKey(e => e.Productid);
				entity.ToTable("Products", "Production");
				entity.HasIndex(e => e.Categoryid, "idx_nc_categoryid");
				entity.HasIndex(e => e.Productname, "idx_nc_productname");
				entity.HasIndex(e => e.Supplierid, "idx_nc_supplierid");
				entity.Property(e => e.Productid).HasColumnName("productid");
				entity.Property(e => e.Categoryid).HasColumnName("categoryid");
				entity.Property(e => e.Discontinued).HasColumnName("discontinued");
				entity.Property(e => e.Productname).HasMaxLength(40).HasColumnName("productname");
				entity.Property(e => e.Supplierid).HasColumnName("supplierid");
				entity.Property(e => e.Unitprice).HasColumnType("money").HasColumnName("unitprice");
				entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.Categoryid).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Products_Categories");
				entity.HasOne(d => d.Supplier).WithMany(p => p.Products).HasForeignKey(d => d.Supplierid).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Products_Suppliers");
			});

			modelBuilder.Entity<ShipperEntity>(entity =>
			{
				entity.HasKey(e => e.Shipperid);
				entity.ToTable("Shippers", "Sales");
				entity.Property(e => e.Shipperid).HasColumnName("shipperid");
				entity.Property(e => e.Companyname).HasMaxLength(40).HasColumnName("companyname");
				entity.Property(e => e.Phone).HasMaxLength(24).HasColumnName("phone");
			});

			modelBuilder.Entity<SupplierEntity>(entity =>
			{
				entity.HasKey(e => e.Supplierid);
				entity.ToTable("Suppliers", "Production");
				entity.HasIndex(e => e.Companyname, "idx_nc_companyname");
				entity.HasIndex(e => e.Postalcode, "idx_nc_postalcode");
				entity.Property(e => e.Supplierid).HasColumnName("supplierid");
				entity.Property(e => e.Address).HasMaxLength(60).HasColumnName("address");
				entity.Property(e => e.City).HasMaxLength(15).HasColumnName("city");
				entity.Property(e => e.Companyname).HasMaxLength(40).HasColumnName("companyname");
				entity.Property(e => e.Contactname).HasMaxLength(30).HasColumnName("contactname");
				entity.Property(e => e.Contacttitle).HasMaxLength(30).HasColumnName("contacttitle");
				entity.Property(e => e.Country).HasMaxLength(15).HasColumnName("country");
				entity.Property(e => e.Fax).HasMaxLength(24).HasColumnName("fax");
				entity.Property(e => e.Phone).HasMaxLength(24).HasColumnName("phone");
				entity.Property(e => e.Postalcode).HasMaxLength(10).HasColumnName("postalcode");
				entity.Property(e => e.Region).HasMaxLength(15).HasColumnName("region");
			});


			modelBuilder.Entity<SpCustomerOrder>(entity =>
			{
				entity.HasNoKey();
				entity.Property(e => e.OrderId).HasColumnName("Orderid");
				entity.Property(e => e.RequiredDate).HasColumnName("Requireddate");
				entity.Property(e => e.ShippedDate).HasColumnName("Shippeddate");
				entity.Property(e => e.ShipName).HasColumnName("Shipname");
				entity.Property(e => e.ShipAddress).HasColumnName("Shipaddress");
				entity.Property(e => e.ShipCity).HasColumnName("Shipcity");
			});

			modelBuilder.Entity<SpEmployee>(entity =>
			{
				entity.HasNoKey();
				entity.Property(e => e.EmployeeId).HasColumnName("Empid");
				entity.Property(e => e.Fullname).HasColumnName("Fullname");
			}); 
			
			modelBuilder.Entity<SpPredictedOrderDate>(entity =>
			{
				entity.HasNoKey();
			});

			modelBuilder.Entity<SpProduct>(entity =>
			{
				entity.HasNoKey();
				entity.Property(e => e.ProductId).HasColumnName("productid");
				entity.Property(e => e.ProductName).HasColumnName("productname");
			});

			modelBuilder.Entity<SpShipper>(entity =>
			{
				entity.HasNoKey();
				entity.Property(e => e.ShipperId).HasColumnName("Shipperid");
				entity.Property(e => e.CompanyName).HasColumnName("Companyname");
			});


			base.OnModelCreating(modelBuilder);
		}

	}
}
