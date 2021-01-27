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
	class Employee
	{
		string name;
		int empId;
		double sal;
		public Employee(string name, int id, double salary)
		{
			this.name = name;
			empId = id;
			sal = salary;
		}
		public void CalHRA()
		{
			Console.WriteLine("*******Employee Details*******");
			Console.WriteLine($"Name is : {name} and id as {empId}");
			Console.WriteLine($"Salary is : {sal} \n");

			sal = sal * 10/100;
			Console.WriteLine($"After deductions sal is : {sal}");
			Console.WriteLine("**********************************");
		}
	}
	class SerializeEmployee
	{
		static void Main()
		{
			//Accepting user defined values
			Console.WriteLine("enter id : ");
			int id = int.Parse(Console.ReadLine());
			Console.WriteLine("enter name : ");
			string name = Console.ReadLine();
			Employee emp = new Employee(name, id, 58620.36);
			FileStream fs = new FileStream(@"D:\EmployeeSal.txt",
				FileMode.OpenOrCreate, FileAccess.ReadWrite);
			BinaryFormatter bfs = new BinaryFormatter();
			bfs.Serialize(fs, emp);

			fs.Seek(0, SeekOrigin.Begin);
			Employee res = (Employee)bfs.Deserialize(fs);
			res.CalHRA();
			fs.Close();
		}
	}
}
