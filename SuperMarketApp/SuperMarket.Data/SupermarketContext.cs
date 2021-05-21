using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperMarket.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Data
{
	public class SupermarketContext:DbContext
	{
		public DbSet<Role> Role { get; set; }
		public DbSet<Staff> Staff { get; set; }
		public DbSet<Address> Address { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Inventory> Inventory { get; set; }
		public DbSet<Supplier> Supplier { get; set; }
		public DbSet<PurchaseOrder> PurchaseOrder { get; set; }


		public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
		{
			builder.AddFilter((category, level) =>
			category == DbLoggerCategory.Database.Command.Name &&
			level == LogLevel.Information
			).AddConsole();

		});

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder
			//.UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging()
			.UseNpgsql("Host=localhost;DataBase=SupermarketDB; username=postgres;password=12345678");
		//optionsBuilder.UseNpgsql("Host=localhost;DataBase=SupermarketDB; username=postgres;password=12345");

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			//configuring staff
			modelBuilder.Entity<Staff>().HasKey(r => r.staffId);
			modelBuilder.Entity<Staff>().Property(r => r.firstname).HasMaxLength(30).IsRequired(); ;
			modelBuilder.Entity<Staff>().Property(r => r.lastname).HasMaxLength(30);
			modelBuilder.Entity<Staff>().Property(r => r.gender).HasMaxLength(1);
			modelBuilder.Entity<Staff>().Property(r => r.phone).HasMaxLength(10);
			modelBuilder.Entity<Staff>().HasOne(f => f.Address).WithMany(a => a.Staff).HasForeignKey(x => x.addressId);
			modelBuilder.Entity<Staff>().HasOne(f => f.Role).WithMany(a=>a.Staff).HasForeignKey(x => x.roleId);



			//configuring address
			modelBuilder.Entity<Address>().HasKey(r => r.addressId);
			modelBuilder.Entity<Address>().Property(r => r.addressLine1).HasMaxLength(30).IsRequired(); 
			modelBuilder.Entity<Address>().Property(r => r.addressLine2).HasMaxLength(30);
			modelBuilder.Entity<Address>().Property(r => r.city).HasMaxLength(30).IsRequired(); 
			modelBuilder.Entity<Address>().Property(r => r.state).HasMaxLength(30).IsRequired(); 
			modelBuilder.Entity<Address>().Property(r => r.pincode).HasMaxLength(6).IsRequired(); ;


			//configuring Role
			modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
			modelBuilder.Entity<Role>().Property(r => r.role).HasMaxLength(30).IsRequired();
			modelBuilder.Entity<Role>().Property(r => r.Description).HasMaxLength(256).IsRequired();

			//configuring Product
			modelBuilder.Entity<Product>().HasKey(r => r.ProductId);


			modelBuilder.Entity<Product>().Property(r => r.ProductName).HasMaxLength(30).IsRequired();
			modelBuilder.Entity<Product>().Property(r => r.Manufacturer).HasMaxLength(30).IsRequired();
			modelBuilder.Entity<Product>().Property(r => r.CategoryId).HasMaxLength(10).IsRequired();
			modelBuilder.Entity<Product>().Property(r => r.ExpiryDate).HasMaxLength(15).IsRequired();
			modelBuilder.Entity<Product>().Property(r => r.CostPrice).HasMaxLength(15).IsRequired();
			modelBuilder.Entity<Product>().Property(r => r.SellingPrice).HasMaxLength(15).IsRequired();


			//configuring Category
			modelBuilder.Entity<Category>().HasKey(r => r.CategoryId);
			modelBuilder.Entity<Category>().Property(r => r.CategoryCode).HasMaxLength(15).IsRequired();
			modelBuilder.Entity<Category>().Property(r => r.CategoryName).HasMaxLength(30).IsRequired();

			//configuring Inventory
			modelBuilder.Entity<Inventory>().HasKey(r => r.InventoryId);
			modelBuilder.Entity<Inventory>().HasOne(x => x.Product).WithOne().HasForeignKey<Inventory>(x => x.ProductId);
			
			modelBuilder.Entity<Inventory>().Property(r => r.Quantity).IsRequired();



			//configuring PurchaseOrder
			modelBuilder.Entity<PurchaseOrder>().HasKey(r => r.PurchaseOrderId);
			modelBuilder.Entity<PurchaseOrder>().HasKey(s => new { s.SupplierId, s.ProductId });
			modelBuilder.Entity<PurchaseOrder>().Property(r => r.SupplierId).HasMaxLength(6).IsRequired();
			modelBuilder.Entity<PurchaseOrder>().Property(r => r.ProductId).HasMaxLength(6).IsRequired();
			modelBuilder.Entity<PurchaseOrder>().Property(r => r.Orderdate).HasMaxLength(11).IsRequired();

			//configuring Supplier
			modelBuilder.Entity<Supplier>().HasKey(r => r.SupplierId);
			modelBuilder.Entity<Supplier>().Property(r => r.SupplierName).HasMaxLength(30).IsRequired();
			modelBuilder.Entity<Supplier>().Property(r => r.phone).HasMaxLength(10).IsRequired();
			modelBuilder.Entity<Supplier>().Property(r => r.email).HasMaxLength(50).IsRequired();
			modelBuilder.Entity<Supplier>().Property(r => r.city).HasMaxLength(20).IsRequired();


			
			base.OnModelCreating(modelBuilder);
		}
	}


}
