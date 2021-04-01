using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.cviceni
{
	class TemperatureArchive
	{
		private SortedDictionary<int, AnnualTemperature> Archive;

		public TemperatureArchive()
		{
			Archive = new SortedDictionary<int, AnnualTemperature>();
		}

		public void AddYearData(AnnualTemperature Yeardata)
		{

			if (Yeardata != null)
			{
				Archive.Add(Yeardata.Year, Yeardata);
			}
		}

		public void Save(string way)
		{
			StreamWriter Writer = File.CreateText(way);


			foreach (var items in Archive) // Write dates of years to SortedDictionary for Years
			{
				Writer.Write(items.Key + ": ");

				for (int i = 0; i < items.Value.MonthlyTemperatures.Count; i++) //Write values of Temperatures from List of Monthly temp. to SortedDictionary for Years
				{
					if (i == 11)
					{
						Writer.Write(items.Value.MonthlyTemperatures[11] + Writer.NewLine);
						break;
					}

					Writer.Write(items.Value.MonthlyTemperatures[i] + "; ");
				}
			}
			Writer.Close();

		}


		public static TemperatureArchive Load(string way)
		{
			TemperatureArchive TMP = new TemperatureArchive();

			using (StreamReader Reader = File.OpenText(way))
			{

				double value;
				string line;


				while ((line = Reader.ReadLine()) != null)
				{

					List<double> Temperatures = new List<double>(); //vytvori List teplot

					line = line.Replace(" ", ""); // smaze mezery

					List<string> values = line.Split(':', ';').ToList();

					for (int i = 1; i < values.Count; i++)
					{
						value = Convert.ToDouble(values[i]);

						Temperatures.Add(value);
					}
					TMP.AddYearData(new AnnualTemperature(Convert.ToInt32(values[0]), Temperatures));
				}
			}
			return TMP;
		}



		public void Calibration(double number)
		{
			Console.WriteLine("Calibration: ");

			foreach (var item in Archive.Values)
			{
				for (int i = 0; i < item.MonthlyTemperatures.Count; i++)
				{
					item.MonthlyTemperatures[i] = item.MonthlyTemperatures[i] + number;
				}
			}
			PrintTemperatures();
		}


		public void Search(int Year)
		{
			Console.WriteLine("Searching: {0} ", Year);

			if (Archive.ContainsKey(Year))
			{
				Console.Write("{0}: ", Archive[Year].Year);

				for (int i = 0; i < Archive[Year].MonthlyTemperatures.Count; i++)
				{
					Console.Write(Archive[Year].MonthlyTemperatures[i] + "; ");
				}
			}
			else
			{
				Console.WriteLine(" Year was not found!");
			}
		}

		public void PrintTemperatures()
		{
			Console.WriteLine("Print Temperatures: ");
			foreach (var item in Archive.Values)
			{
				Console.Write("{0}: ", item.Year);
				for (int i = 0; i < item.MonthlyTemperatures.Count; i++)
				{
					if (i + 1 == item.MonthlyTemperatures.Count)
					{
						Console.Write("{0:0.0} ", item.MonthlyTemperatures[i]);
					}
					else
						Console.Write("{0:0.0}; ", item.MonthlyTemperatures[i]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();

		}


		public void PrintAnnualTemperatures()
		{
			/*foreach (var item in Archive.Values)
			{
				Console.WriteLine("{0}", item.Year);
				Console.WriteLine("{0}", item.AverageTemperature);

			}
			Console.WriteLine();*/
		}

		public void PrintMonthlyTemperatures()
		{

		}
	}
}