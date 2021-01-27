using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Work27Jan
{
	//2methods work sim
	class MultithreadConcept
	{
		static void Countup()
		{
			for (int i = 0; i <= 10; i++)
			{
				Console.Write(i + "-->");
				Thread.Sleep(500);
			}
			Console.WriteLine();
		}
		static void CountDown()
		{
			for (int i = 10; i > 0; i--)
			{
				Console.Write(i+ ",");
				Thread.Sleep(1000);
			}
			Console.WriteLine();
		}
		static void Main()
		{
			ThreadStart ts = new ThreadStart(MultithreadConcept.Countup);
			Thread th = new Thread(ts);
			th.Start();
			MultithreadConcept.Countup();
			MultithreadConcept.CountDown();
		}
	}
}
