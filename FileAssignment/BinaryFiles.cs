using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment26Jan
{
	class BinaryFiles
	{
		public BinaryFiles()
		{
			Writer();
			Reader();
		}
		static void Main()
		{
			BinaryFiles bs = new BinaryFiles();
			Console.ReadLine();
		}

		private void Writer()
		{
			try
			{
				Console.Out.WriteLine("***********************");
				FileStream fs = new FileStream(@"D:\aboutme.txt", FileMode.OpenOrCreate,
				FileAccess.Write, FileShare.ReadWrite);
				BinaryWriter bw = new BinaryWriter(fs);
				//Details
				string name = "Siri";
				int age = 22;
				double marks = 96.5;
				bw.Write(name);
				bw.Write(age);
				bw.Write(marks);
				bw.Close();
				Console.WriteLine("Data Stored");
				Console.WriteLine();
			}
			catch (IOException e)
			{
				Console.WriteLine("An IO Exception Occurred :" + e);
			}
		}
		private void Reader()
		{
			try
			{
				Console.WriteLine("Details abt me!!!");

				//Open a FileStream in Read mode
				FileStream fin = new FileStream(@"D:\aboutme.txt", FileMode.Open,
				FileAccess.Read, FileShare.ReadWrite);
				BinaryReader br = new BinaryReader(fin);

				//Seek to the start of the file
				br.BaseStream.Seek(0, SeekOrigin.Begin);

				//Read from the file and store the values to the variables
				string name = br.ReadString();
				int age = br.ReadInt32();
				double marks = br.ReadDouble();

				//Display the data on the console
				Console.WriteLine("Name  :" + name);
				Console.WriteLine("Age   :" + age);
				Console.WriteLine("Marks :" + marks);
				Console.WriteLine("********First Class with Distinction*****");
				br.Close();
			}
			catch (IOException e)
			{
				Console.WriteLine("An IO Exception Occurred :" + e);
			}
		}
	}
}

	