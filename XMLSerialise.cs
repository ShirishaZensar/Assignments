using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace Work27Jan
{
	class XMLSerialise
	{
		static void Main()
		{
			int luckyNo = 20;
			FileStream fs = new FileStream(@"D:\XmlData.xml",
				FileMode.OpenOrCreate, FileAccess.ReadWrite);
			XmlSerializer xs = new XmlSerializer(typeof(int));
			xs.Serialize(fs, luckyNo);

			fs.Seek(0, SeekOrigin.Begin);

			int res = (int)xs.Deserialize(fs);//unboxing obj to int
			Console.WriteLine(res + " After deserialing");
		}
	}
}
