using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Work27Jan
{
	class LinqFiles
	{
		static long GetFileLength(string filename)
		{
			long returnValue;
			FileInfo fi;
			try
			{
				fi = new FileInfo(filename);
				returnValue = fi.Length;
			}
			catch (FileNotFoundException)
			{
				returnValue = 0;
			}
			finally
			{ }
			return returnValue;
		}
		static void Main()
		{
			var path = @"D:\.NetBatch2021";
			DirectoryInfo di = new DirectoryInfo(path);
			var fileList = di.GetFiles("*.*",SearchOption.AllDirectories);
			var fileQue = from file in fileList
						  select GetFileLength(file.FullName);
			//cache res to avoid multiple trips to dir
			var result = fileQue.ToArray();
			var largeFile = result.Max();
			var TotalByte = result.Sum();
			Console.WriteLine($"File details as : {result}");
			Console.WriteLine("Large File as : "+ largeFile);
			Console.WriteLine($"Byte of File as : {TotalByte}");
			Console.ReadLine();
		}
	}
}
