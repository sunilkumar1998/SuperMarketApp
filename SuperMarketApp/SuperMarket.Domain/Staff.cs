using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Domain
{
	public class Staff
	{
		public int staffId { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string gender { get; set; }
		public long phone { get; set; }

		public int roleId { get; set; }
		public int addressId { get; set; }

		public Role Role { get; set; }
		public Address Address { get; set; }
	}
}
