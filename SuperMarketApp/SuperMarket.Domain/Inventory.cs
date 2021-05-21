using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Domain
{
	public class Inventory
	{
		public  int InventoryId { get; set; }
		public int ProductId { get; set; }
		public long Quantity { get; set; }

		public Product Product { get; set; }

	}
}
