using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace Work27Jan
{
	[Serializable]
	class Product
	{
		public int ProdId { get; set; }
		public string ProdName { get; set; }
		public double Price { get; set; }
		public int ProdQuantity { get; set; }
		public Product()
		{

		}
		public Product(int id,string name,double _price, int quantity)
		{
			ProdId=id;
			ProdName = name;
			Price = _price;
			ProdQuantity = quantity;
		}
		public double TotalAmount()
		{
			return Price * ProdQuantity;
		}
	}
	class SoapSerialise
	{
		static void Main()
		{
			Product p = new Product(101,"EarPods",500.36,4);
			FileStream fs = new FileStream(@"D:\Product.txt",
				FileMode.OpenOrCreate, FileAccess.ReadWrite);
			SoapFormatter sf = new SoapFormatter();
			sf.Serialize(fs,p);

			fs.Seek(0, SeekOrigin.Begin);
			Product res = (Product)sf.Deserialize(fs);
			Console.WriteLine("Amount of Product : "+ res.TotalAmount());
			fs.Close();

		}
	}
}
