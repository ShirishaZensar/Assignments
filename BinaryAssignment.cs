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
	class PersonAge : IDeserializationCallback
	{
		[NonSerialized]
		int Age = 0;

		public string Name { get; set; }

		public void OnDeserialization(object sender)
		{
			Console.WriteLine($"**********{Name} Details**************");
			var today = DateTime.Today;

			DateTime bday = new DateTime(1998, 12, 11); // YY/MM/DD
			Console.WriteLine("My Birth Date : " + bday.ToString());

			// Calculate the age
			int age = today.Year - bday.Year;
			Console.WriteLine("\n");
			Console.WriteLine($"Total age in years : {age} yrs");
			Console.WriteLine("************************************");
		}

	}

	class BinaryAssignment
	{
		static void Main()
		{
			PersonAge pa = new PersonAge();
			pa.Name = "Siri";
			FileStream fs = new FileStream(@"D:\PersonAging.txt",
						FileMode.OpenOrCreate, FileAccess.ReadWrite);
			BinaryFormatter bfs = new BinaryFormatter();
			bfs.Serialize(fs, pa);

			fs.Seek(0, SeekOrigin.Begin);
			PersonAge res = (PersonAge)bfs.Deserialize(fs);
		}
	}
}
