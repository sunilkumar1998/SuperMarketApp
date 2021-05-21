using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Domain
{
	public class Role
	{
		public int RoleId { get; set; }
		public string role { get; set; }
		public ICollection<Staff> Staff { get; set; }
		public string Description { get; set; }

		
	}
}
