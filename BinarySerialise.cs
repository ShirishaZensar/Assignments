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
	class PersonEg
	{
		public int Age { get; set; }

		public string Name { get; set; }

		public long mobileNo { get; set; }
		public void ShowDetails()
		{
			Console.WriteLine("*******Person Details*******");
			Console.WriteLine($"Name is : {Name} and age as : {Age}");
			Console.WriteLine($"Mobile number is : {mobileNo}");
			Console.WriteLine("**********************************");
		}
	}
	class BinarySerialise
	{
		static void Main()
		{
			PersonEg pe = new PersonEg();
			pe.Name = "Siri";
			pe.Age = 22;
			pe.mobileNo = 9658745854;
			FileStream fs = new FileStream(@"D:\Person.txt",
				FileMode.OpenOrCreate, FileAccess.ReadWrite);
			BinaryFormatter bfs = new BinaryFormatter();
			bfs.Serialize(fs, pe);

			fs.Seek(0, SeekOrigin.Begin);
			PersonEg res=(PersonEg)bfs.Deserialize(fs);
			res.ShowDetails();
		}
	}
}
