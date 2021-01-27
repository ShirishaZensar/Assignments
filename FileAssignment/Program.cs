using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment26Jan
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter the text : ");
			string stmt = null;
			FileStream fs = new FileStream(@"D:\FileStmt2.txt",
				             FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter sw = new StreamWriter(fs);
			sw.WriteLine(stmt);
			//Condition as Write 5 lines
			/*for (int i = 0; i < 5; i++)
			{
				stmt = Console.ReadLine();
				sw.WriteLine(stmt);
			}*/
			while (stmt != "Hi")
			{
				stmt = Console.ReadLine();
				if (stmt != "Hi")
				{
						sw.WriteLine(stmt);
				}
			}
			sw.Close();
			fs.Close();
		}
	}
}