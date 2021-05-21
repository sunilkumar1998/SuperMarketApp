using SuperMarket.Data;
using SuperMarket.Domain;
using System;
using System.Linq;

namespace SuperMarketApp
{
	class Program
	{
		public static SupermarketContext context = new SupermarketContext(); 
		static void Main(string[] args)
		{
			//deleteTableData();
			//AddStaffs();
			//AddRole();
			//AddAddress();
			//Addproducts();
			//AddSupplier();
			//AddPurchaseOrder();
			Query.RunQueries();
			//AddInventory();
			//updateRecord();
		}

		private static void updateRecord()
		{
			var updateproduct = context.Product.First(i => i.ProductId == 7);
			updateproduct.CategoryId = 1;
			context.Product.Update(updateproduct);
			context.SaveChanges();

		}

		private static void AddInventory()
		{
			var Inventorydetail = new Inventory
			{
				ProductId = 6,
				Quantity = 65
			};
			
			context.Inventory.Add(Inventorydetail);
			context.SaveChanges();
			Console.WriteLine("Successfully added to Inventory");
		}

		private static void AddSupplier()
		{
			
			var supplierdetails = new Supplier
			{
				SupplierName = "Ruchi wholesale ltd",
				phone=8465432897,
				email="ruchigurgaon@gmail.com",
				city="Gurgaon",
				
				
			};
			context.Supplier.Add(supplierdetails);
			context.SaveChanges();
			Console.WriteLine("Successfully added");
		}

		private static void AddPurchaseOrder()
		{
			DateTime dateordered = new DateTime(2021, 05, 15);

			var order = new PurchaseOrder {
				SupplierId = 4,
				ProductId=6,
				Orderdate=dateordered
			};
			context.PurchaseOrder.Add(order);
			context.SaveChanges();
			Console.WriteLine("Successfully added");
		}

		private static void Addproducts() {

			var category = new Category
			{
				CategoryCode = "bev",
				CategoryName = "beverages",
			};
			DateTime date1 = new DateTime(2021, 07, 29);
			var prod = new Product()
			{
				ProductName = "Slice",
				Manufacturer = "pepsiCo Inc",
				ExpiryDate = date1,
				CostPrice = 35,
				SellingPrice = 40,
				Category = category
			};

			context.Product.Add(prod);
			context.SaveChanges();
			Console.WriteLine("Successfully Added");
		}

		private static void AddStaffs()
		{
			var address = new Address
			{
				addressLine1 = "NJF-340",
				addressLine2="Jharoda kla",
				city = "Najafgarh",
				state = "Delhi",
				pincode = 143034
			};

			var role = new Role
			{
				role = "Inventory manager",
				Description = "keep record of Inventory "
			};

			var staff = new Staff
			{
				firstname = "Gaurav",
				lastname="Kumar",
				phone = 8878882496,
				gender="M",
				Address = address,
				Role = role
			};

			//context.address.Add(add)
			context.Staff.Add(staff);
			context.SaveChanges();
		}


		private static void AddRole()
		{
			var roleData = new Role { role = "Inventory keeper" , Description= "person who keeps record of Inventory" };
			
			context.Role.Add(roleData);
			context.SaveChanges();
			Console.WriteLine("successfully added");
		}


		private static void AddAddress()
		{
			var addressData = new Address {
					addressLine1="MUM-34",
					addressLine2="Film City",
					city="Alwar",
					state="Rajasthan",
					pincode=240093

			};
			context.Address.Add(addressData);
			context.SaveChanges();
			Console.WriteLine("successfully added");
		}

		public static  void deleteTableData() {
			
		var stafftodelete = context.Role.ToList();
			context.Role.RemoveRange(stafftodelete);

			try
			{
				context.SaveChanges();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}

		private static void AddStaff()
		{
			Role r = new Role();
			r.RoleId = 2;
			r.role = "manager";
			r.Description = "person of highest authority";
			
			var staff = new Staff { firstname ="HARSHIT",
				lastname="Pandey",
				gender="M",
				phone=9732134422,
				Role=r, 
				
			};
			context.Staff.Add(staff);
			context.SaveChanges();
		}

		//private static void GetSamurais(string text)
		//{
		//	var staffs = context.stafs;
		//	Console.WriteLine($"{text}: Staff count is {staffs.Count}");
		//	foreach (var samurai in samurais)
		//	{
		//		Console.WriteLine(samurai.Name);
		//	}
		//}
	}
}
