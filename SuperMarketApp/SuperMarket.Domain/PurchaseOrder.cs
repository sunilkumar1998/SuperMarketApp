using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Domain
{
	public class PurchaseOrder
	{
		public int PurchaseOrderId { get; set; }
		public int ProductId { get; set; }
		public int SupplierId { get; set; }
		public DateTime Orderdate { get; set; }

		public Product Product { get; set; }
		public Supplier Supplier { get; set; }
	}
}
