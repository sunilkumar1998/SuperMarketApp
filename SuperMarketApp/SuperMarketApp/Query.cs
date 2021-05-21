using SuperMarket.Data;
using SuperMarket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarketApp
{
	public static class Query
	{
		public static SupermarketContext context = new SupermarketContext();

		public static void RunQueries() {
			Boolean flag = true;
			Console.WriteLine("Welcome to the Queries menu \n Enter the number of query you want to execute");
			while (flag)
			{
				Console.WriteLine("\n\n\n1.  Query Staff using name or phone number or both");
				Console.WriteLine("2.  Query Staff using their Role");
				Console.WriteLine("3.  Query Product based on -\n\ta. Name\nb\tb.Category\n\tc.InStock, OutOfStock\n");
				Console.WriteLine("4.  Query product which are out of stock");
				Console.WriteLine("5.  Number of Products within a category");
				Console.WriteLine("6.  Product-Categories listed in descending with highest number of products to the lowest number of products");
				Console.WriteLine("7.  List of Suppliers  -\n\ta. Name\nb\tb.Phone\n\tc.Email\n\td. city/state \n");

				Console.WriteLine("8.  List of Product with different suppliers");
				Console.WriteLine("9.  Exit?");




				int ch = Convert.ToInt32(Console.ReadLine());
				switch (ch)
				{
					case 1:
						{
							Filterstaff();
							
							break;
						}

					case 2:
						{
							filterthroughRole();
							break;
						}

					case 3:
						{
							QueryProduct();
							break;
						}

					case 4:
						{
							NumberOfProductPutofStock();
							break;
						}

					case 5:
						{
							NumberofProductswithinacategory();
							break;
						}

					case 6:
						{
							CategorieslistedindescendingwithQuantity();
							break;
						}

					case 7:
						{
							Listsupplier();
							break;
						}

					case 8:
						{
							ListofProductwithdifferentsuppliers();
							break;
							
						}

					case 9:
						{
							//Console.WriteLine("Want to Exit?");
							//string choice = Console.ReadLine();
							//if (choice == "y" || choice == "Y")
								flag = false;
							break;
						}
				}
			}
		}

		

		public static void Filterstaff()
		{
			var staff = context.Staff.Where(s => s.firstname == "Swati" || s.phone== 9978882723).ToList();
			Console.WriteLine("StaffId\t firstname\t lastname\t gender\t phone\t roleId\t addressId");
			foreach (var v in staff)
			{
				
				Console.WriteLine("\t" + v.staffId + "\t" + v.firstname + "\t" + v.lastname
					+ "\t" + v.gender + "\t" + v.phone + "\t" + v.roleId + "\t" + v.addressId);
			}

			



		}

		public static void  filterthroughRole() {
			var staffrole = context.Staff.Where(s => s.roleId == 7).ToList();
			foreach (var v in staffrole)
			{
				Console.WriteLine("StaffId\t firstname\t lastname\t gender\t phone\t roleId\t addressId");
				Console.WriteLine("\t" + v.staffId + "\t" + v.firstname + "\t" + v.lastname
					+ "\t" + v.gender + "\t" + v.phone + "\t" + v.roleId + "\t" + v.addressId);
			}

			var stf = (from p in context.Staff
					   join e in context.Role
					   on p.roleId equals e.RoleId
					   where e.role == "Manager"
					   select new
					   {
						   ID = p.roleId,
						   FirstName = p.firstname,
						   LastName = p.lastname,
						   Role = e.role,
					   }).ToList();
			foreach (var x in stf)
			{
				Console.WriteLine(x.ID + "\t" + x.FirstName + "\t" + x.LastName + "\t" + x.Role);
			}
		}


		public static void QueryProduct() 
		{
			Console.WriteLine("Based on Name : ");
			var prod= context.Product.Where(s => s.ProductName == "frooti").ToList();
			Console.WriteLine(" productId\t name\t manufacturer \t C.P\t  S.P\t categoryId");
			foreach (var p in prod)
			{				
				Console.WriteLine("\t" + p.ProductId + "\t" + p.ProductName + "\t" + p.Manufacturer
					 + p.CostPrice + "\t" + p.SellingPrice + "\t" + p.CategoryId);
			}

			Console.WriteLine("Based on category : ");
			var prodc = (from p in context.Product
						 join e in context.Category
						 on p.CategoryId equals e.CategoryId
						 where e.CategoryCode == "soap"
						 select new
						 {
							 p,e
						 });
			Console.WriteLine(" productId\t name\t manufacturer \t catId\t  catCode\t catname");
			foreach (var v in prodc)
			{
				
				Console.WriteLine("\t" + v.p.ProductId + "\t" + v.p.ProductName + "\t" + v.p.Manufacturer+"\t"
					 + v.e.CategoryId + "\t" + v.e.CategoryCode + "\t" + v.e.CategoryName);
			}


			Console.WriteLine("Based on Instock/Outstock : ");
			var prodI = (from p in context.Product
						 join e in context.Inventory
						 on p.ProductId equals e.ProductId
						 where e.Quantity > 0
						 select new
						 {
							 p,
							 e
						 });
			Console.WriteLine(" productId\t name\t manufacturer \t InventoryId\t  Quantity");
			foreach (var v in prodI)
			{
				Console.WriteLine("\t" + v.p.ProductId + "\t" + v.p.ProductName + "\t" + v.p.Manufacturer + "\t"
					 + v.e.InventoryId + "\t" + v.e.Quantity );
			}


			Console.WriteLine("SP less than, greater than or between : ");
			var prodbySP = context.Product.Where(s => s.SellingPrice >10 && s.SellingPrice<60).ToList();
			Console.WriteLine(" productId\t name\t manufacturer \t C.P\t  S.P\t categoryId");
			foreach (var p in prodbySP)
			{
				Console.WriteLine("\t" + p.ProductId + "\t" + p.ProductName + "\t" + p.Manufacturer
					 + p.CostPrice + "\t" + p.SellingPrice + "\t" + p.CategoryId);
			}
		}



		public static void NumberOfProductPutofStock()
		{
			Console.WriteLine("Based on Product Out of stock : ");
			var prodI = (from p in context.Product
						 join e in context.Inventory
						 on p.ProductId equals e.ProductId
						 where e.Quantity < 0
						 select new
						 {
							 p,
							 e
						 });
			Console.WriteLine(" productId\t name\t manufacturer \t InventoryId\t  Quantity");
			foreach (var v in prodI)
			{
				Console.WriteLine("\t" + v.p.ProductId + "\t" + v.p.ProductName + "\t" + v.p.Manufacturer + "\t"
					 + v.e.InventoryId + "\t" + v.e.Quantity);
			}
		}

		public static void NumberofProductswithinacategory()
		{
			var result = (from p in context.Product
						  join c in context.Category
						  on p.CategoryId equals c.CategoryId
						  group p by c.CategoryId into x
						  select new
						  {
							  Count = x.Count<Product>(),
							  Category_Id = x.Key
						  }).ToList();

			foreach (var i in result)
			{
				Console.WriteLine("Category_ID : " + i.Category_Id);
				Console.WriteLine("Count : " + i.Count);
			}

		}



		public static void CategorieslistedindescendingwithQuantity()
		{
			var result = (from p in context.Product
						  join c in context.Category
						  on p.CategoryId equals c.CategoryId
						  group p by c.CategoryId into x
						  orderby x.Count<Product>() descending
						  select new
						  {
							  Count = x.Count<Product>(),
							  Category_Id = x.Key
						  }).ToList();

			foreach (var i in result)
			{
				Console.WriteLine("Category_ID : " + i.Category_Id);
				Console.WriteLine("Count : " + i.Count);
			}
		}


		
		private static void Listsupplier()
		{
			Console.WriteLine("Based on name \n");

			var suppliernamefilter = context.Supplier.Where(s =>s.SupplierName== "Vitran Distributor").ToList();
			Console.WriteLine(" Id\t name\t phone \t email\t  city");
			foreach (var v in suppliernamefilter)
			{
				Console.WriteLine("\t" + v.SupplierId + "\t" + v.SupplierName + "\t" + v.phone + "\t"
					 + v.email + "\t" + v.city);
			}

			Console.WriteLine("Based on phone number\n ");

			var supplierPhonefilter = context.Supplier.Where(s => s.phone ==9765432876).ToList();
			Console.WriteLine(" Id\t name\t phone \t email\t  city");
			foreach (var v in supplierPhonefilter)
			{
				Console.WriteLine("\t" + v.SupplierId + "\t" + v.SupplierName + "\t" + v.phone + "\t"
					 + v.email + "\t" + v.city);
			}


			Console.WriteLine("Based on phone number \n");

			var supplierEmailfilter = context.Supplier.Where(s => s.email == "jagdish@gmail.com").ToList();
			Console.WriteLine(" Id\t name\t phone \t email\t  city");
			foreach (var v in supplierEmailfilter)
			{
				Console.WriteLine("\t" + v.SupplierId + "\t" + v.SupplierName + "\t" + v.phone + "\t"
					 + v.email + "\t" + v.city);
			}


			Console.WriteLine("Based on city/state \n");

			var supplierCityfilter = context.Supplier.Where(s => s.city == "Gurgaon").ToList();
			Console.WriteLine(" Id\t name\t phone \t email\t  city");
			foreach (var v in supplierCityfilter)
			{
				Console.WriteLine("\t" + v.SupplierId + "\t" + v.SupplierName + "\t" + v.phone + "\t"
					 + v.email + "\t" + v.city);
			}
		}

		private static void ListofProductwithdifferentsuppliers()
		{

			//var filter1 = from p in context.Product
			//			  join e in context.PurchaseOrder
			//			  on p.ProductId equals e.ProductId
			//			  join Inv in context.Inventory
			//			  on p.ProductId equals Inv.ProductId
			//			 join sup in context.Supplier
			//			 on e.SupplierId  equals sup.SupplierId orderby e.Orderdate
			//			 select new { 
			//				p,e,sup, Inv
			//			 };


			//Console.WriteLine("Product Id \t Product\t supplier Name\t quantity \t date");
			//foreach (var v in filter1) {
			//	Console.WriteLine(v.p.ProductId+"\t\t"+v.p.ProductName + "\t" + v.sup.SupplierName + "\t" + v.Inv.Quantity + "\t" + v.e.Orderdate);
			//}


			Console.WriteLine("filter1 based on Product name");
			var filter2 = from p in context.Product
						  join e in context.PurchaseOrder
						  on p.ProductId equals e.ProductId
						  join Inv in context.Inventory
						  on p.ProductId equals Inv.ProductId
						  join sup in context.Supplier
						  on e.SupplierId equals sup.SupplierId
						  where p.ProductName.Contains("frooti")
						  orderby e.Orderdate
						  select new
						  {
							  p,
							  e,
							  sup,
							  Inv
						  };
			Console.WriteLine("Product Id \t Product\t supplier Name\t quantity \t date");
			foreach (var v in filter2)
			{
				Console.WriteLine(v.p.ProductId + "\t\t" + v.p.ProductName + "\t" + v.sup.SupplierName + "\t" + v.Inv.Quantity + "\t" + v.e.Orderdate);
			}



			Console.WriteLine("filter1 based on Supplier name");
			var filter3 = from p in context.Product
						  join e in context.PurchaseOrder
						  on p.ProductId equals e.ProductId
						  join Inv in context.Inventory
						  on p.ProductId equals Inv.ProductId
						  join sup in context.Supplier
						  on e.SupplierId equals sup.SupplierId
						  where sup.SupplierName.Contains("Vitran")
						  orderby e.Orderdate
						  select new
						  {
							  p,
							  e,
							  sup,
							  Inv
						  };
			Console.WriteLine("\nProduct Id \t Product\t supplier Name\t quantity \t date");
			foreach (var v in filter3)
			{
				Console.WriteLine(v.p.ProductId + "\t\t" + v.p.ProductName + "\t" + v.sup.SupplierName + "\t" + v.Inv.Quantity + "\t" + v.e.Orderdate);
			}


			Console.WriteLine("filter1 based on category Code");
			var filter4 = from p in context.Product
						  join c in context.Category
						  on p.ProductId equals c.CategoryId
						  join e in context.PurchaseOrder
						  on p.ProductId equals e.ProductId
						  join Inv in context.Inventory
						  on p.ProductId equals Inv.ProductId
						  join sup in context.Supplier
						  on e.SupplierId equals sup.SupplierId
						  where c.CategoryCode.Contains("soap")
						  orderby e.Orderdate
						  select new
						  {
							  p,
							  e,
							  sup,
							  Inv
						  };
			Console.WriteLine("\nProduct Id \t Product\t supplier Name\t quantity \t date");
			foreach (var v in filter4)
			{
				Console.WriteLine(v.p.ProductId + "\t\t" + v.p.ProductName + "\t" + v.sup.SupplierName + "\t" + v.Inv.Quantity + "\t" + v.e.Orderdate);
			}


			Console.WriteLine("supplied after a particular date ");
			DateTime date = new DateTime(2021, 05, 11);
			var filter5 = from p in context.Product
						  join c in context.Category
						  on p.ProductId equals c.CategoryId
						  join e in context.PurchaseOrder.Where(x=>x.Orderdate> date)
						  on p.ProductId equals e.ProductId
						  join Inv in context.Inventory
						  on p.ProductId equals Inv.ProductId
						  join sup in context.Supplier
						  on e.SupplierId equals sup.SupplierId
						  
						  orderby e.Orderdate
						  select new
						  {
							  p,
							  e,
							  sup,
							  Inv
						  };
			Console.WriteLine("\nProduct Id \t Product\t supplier Name\t quantity \t date");
			foreach (var v in filter5)
			{
				Console.WriteLine(v.p.ProductId + "\t\t" + v.p.ProductName + "\t" + v.sup.SupplierName + "\t" + v.Inv.Quantity + "\t" + v.e.Orderdate);
			}




			Console.WriteLine("Product has inventory more than or less than a given qty");
			
			var filter6 = from p in context.Product
						  join c in context.Category
						  on p.ProductId equals c.CategoryId
						  join e in context.PurchaseOrder
						  on p.ProductId equals e.ProductId
						  join Inv in context.Inventory.Where(x=>x.Quantity>30)
						  on p.ProductId equals Inv.ProductId
						  join sup in context.Supplier
						  on e.SupplierId equals sup.SupplierId

						  orderby e.Orderdate
						  select new
						  {
							  p,
							  e,
							  sup,
							  Inv
						  };
			Console.WriteLine("\nProduct Id \t Product\t supplier Name\t quantity \t date");
			foreach (var v in filter6)
			{
				Console.WriteLine(v.p.ProductId + "\t\t" + v.p.ProductName + "\t" + v.sup.SupplierName + "\t" + v.Inv.Quantity + "\t" + v.e.Orderdate);
			}
		}

	}
}
