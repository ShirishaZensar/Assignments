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
	class SerializingObjects
	{
		static void Main()
		{
			int age = 20;
			string name = "Siri";
			//fs- stream object
			FileStream fs = new FileStream(@"D:\IntData.txt",
				FileMode.OpenOrCreate,FileAccess.ReadWrite);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs,age);
			bf.Serialize(fs, name);
			//Used to read from starting
			fs.Seek(0, SeekOrigin.Begin);

			int res= (int)bf.Deserialize(fs);//unboxing obj to int
			Console.WriteLine(res + " After deserialing");

			string resultName = (string)bf.Deserialize(fs);//unboxing obj to int
			Console.WriteLine("Name as :" + resultName);
		}
	}
}
