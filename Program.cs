using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Work27Jan
{
	class Program
	{
		static void Main(string[] args)
		{
			var startFolder = @"D:\.NetBatch2021";
			DirectoryInfo di = new DirectoryInfo(startFolder);
			var fileList = di.GetFiles("*.*",SearchOption.AllDirectories);
			var fileQuery = from file in fileList
							where file.Extension == ".txt"
							orderby file.Name
							select file;
			Console.WriteLine("All files with .txt Extension \n");
			foreach (var v in fileQuery)
			{
				Console.WriteLine(v.FullName + " --> "+ v.Extension);
			}

			//Using Lambda expressions
			var queryLambda = fileList.Where(f => f.Extension == ".txt").
				OrderBy(f => f.Name);
			Console.WriteLine("\n Using Lambda files \n");
			foreach (var v in queryLambda)
			{
				Console.WriteLine(v.FullName + " --> " + v.Extension);
			}
		}
	}
}
