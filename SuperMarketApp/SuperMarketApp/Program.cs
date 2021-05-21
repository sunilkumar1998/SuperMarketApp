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
			Console.WriteLine("Welcome");
			Console.WriteLine("\n1.  Perform query Operations: \n2.  Manipulate Database ");


			int ch = Convert.ToInt32(Console.ReadLine());
			switch (ch)
			{
				case 1:
					{
						Query.RunQueries();
						break;
					}

				case 2:
					{
						Operations.doOperations();
						break;
					}

				default: {

						Console.WriteLine("invalid choice");
						break;
						}
			}
					
		}


	}
}
