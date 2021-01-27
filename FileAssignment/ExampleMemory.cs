using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment26Jan
{
	class ExampleMemory
	{
		static void Main()
		{   // Object with capacity of 100 bytes.
			MemoryStream memoryStream = new MemoryStream(10);

			byte[] javaBytes = Encoding.UTF8.GetBytes("Java");
			byte[] csharpBytes = Encoding.UTF8.GetBytes("CSharp");
			memoryStream.Write(javaBytes, 0, javaBytes.Length);
			memoryStream.Write(csharpBytes, 0, csharpBytes.Length);
			Console.WriteLine("Capacity: {0} , Length: {1}",
								  memoryStream.Capacity.ToString(),
								  memoryStream.Length.ToString());

			Console.WriteLine("Position: " + memoryStream.Position);

			// Move the cursor backward 6 bytes, compared to the current position.
			memoryStream.Seek(-6, SeekOrigin.Current);

			Console.WriteLine("***Using GetBuffer and AsEnumerable***");
			byte[] allBytes = memoryStream.GetBuffer();
			var ie= allBytes.AsEnumerable();
			foreach (var data in ie)
			{
				Console.WriteLine(data);
			}

			Console.WriteLine("****CopyTo*****");
			MemoryStream dest = new MemoryStream();
			memoryStream.CopyTo(dest);
			Console.WriteLine("Destination length: {0}", dest.Length.ToString()+"\n");

			Console.WriteLine("*****WriteLine in console***");
			Console.WriteLine("Finish!");
			Console.Read();
		}
	}

}