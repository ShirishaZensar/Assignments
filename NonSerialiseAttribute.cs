using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Work27Jan
{
	[Serializable]
	class ProductClass : IDeserializationCallback
	{
		public int Pid;

		public double Price;

		public int Quantity;

		[NonSerialized]
		public double TotalAmt;

		public ProductClass()
		{

		}
		public ProductClass(int id,double price,int qty)
		{
			Pid = id;
			Price = price;
			Quantity = qty;
		}
		public void OnDeserialization(object sender)
		{
			TotalAmt = Price * Quantity;
		}
	}
	class NonSerialiseAttribute 
	{
		static void Main()
		{
			ProductClass pc = new ProductClass(100, 200, 5);
			FileStream fs = new FileStream(@"D:\ProductExample.txt",
				FileMode.OpenOrCreate, FileAccess.ReadWrite);
			BinaryFormatter bfs = new BinaryFormatter();
			bfs.Serialize(fs, pc);

			fs.Seek(0, SeekOrigin.Begin);
			ProductClass res = (ProductClass)bfs.Deserialize(fs);
			Console.WriteLine("Amount as : "+res.TotalAmt);
		}
	}
}
