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
	[Serializable]
	[XmlRoot("Employee")]
	public class EmployeeDetails
	{
	[XmlIgnore]	public int EmpId;
		public string EmpName;
		public double salary;

		public EmployeeDetails()
		{

		}
		public EmployeeDetails(int id, string name, double _salary)
		{
			EmpId = id;
			EmpName = name;
			salary = _salary;
		}
		public void CalHRA()
		{
			Console.WriteLine("*******Employee Details*******");
			Console.WriteLine($"Name is : {EmpName} and id as {EmpId}");
			Console.WriteLine($"Salary is : {salary} \n");

			salary = salary * 10 / 100;
			Console.WriteLine($"After deductions sal is : {salary}");
			Console.WriteLine("**********************************");
		}
	}
	class XmlEmpEg
	{
		static void Main()
		{
			EmployeeDetails ed = new EmployeeDetails(100,"Siri",52366.36);
			FileStream fs = new FileStream(@"D:\XmlEmpData3.xml",
							FileMode.OpenOrCreate, FileAccess.ReadWrite);
			XmlSerializer xs = new XmlSerializer(typeof(EmployeeDetails));
			xs.Serialize(fs, ed);

			fs.Seek(0, SeekOrigin.Begin);

			EmployeeDetails res = (EmployeeDetails)xs.Deserialize(fs);
			res.CalHRA();
		}
	}
}
