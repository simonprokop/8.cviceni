using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.cviceni
{
	class Program
	{
		static void Main(string[] args)
		{


			TemperatureArchive archive = TemperatureArchive.Load("D:\\Archive.txt");

			archive.Calibration(-5);

			archive.Search(2010);

			archive.PrintAnnualTemperatures();

			archive.PrintMonthlyTemperatures();

			archive.PrintTemperatures();

			archive.Save("D:\\Archive.txt");


			Console.ReadLine();
		}
	}
}
