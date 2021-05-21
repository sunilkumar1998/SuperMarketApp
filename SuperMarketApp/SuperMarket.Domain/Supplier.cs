using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Domain
{
	public class Supplier
	{
		public int SupplierId { get; set; }
		public string SupplierName { get; set; }
		public long phone { get; set; }
		public string email { get; set; }
		public string city { get; set; }
		public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
	}
}
