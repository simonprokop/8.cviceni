using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.cviceni
{
	public class AnnualTemperature
	{
		private int year;
		private double maxTemperature;
		private double minTemperature;
		private double averageTemperature;

		public AnnualTemperature(int Year, List<double> YearTemperatures)
		{
			year = Year;
			MonthlyTemperatures = YearTemperatures;

		}

		public List<double> MonthlyTemperatures
		{ get; set; }

		public int Year
		{

			get { return year; }

			protected set
			{
				if (year < 0 || year > 2021)
				{ throw new ArgumentOutOfRangeException($" For {nameof(year)} have no temperatures!"); }

			}
		}

		public double MaxTemperature
		{
			get
			{
				if (MonthlyTemperatures.Count == 0)
				{
					throw new ArgumentException("List of monthly temperatures is empty");
				}

				return maxTemperature = MonthlyTemperatures.Max();
			}
		}

		public double MinTemperature
		{
			get
			{
				if (MonthlyTemperatures.Count == 0)
				{
					throw new ArgumentException("List of monthly temperatures is empty");
				}
				return minTemperature = MonthlyTemperatures.Min();
			}
		}
		public double AverageTemperature
		{
			get
			{
				if (MonthlyTemperatures.Count == 0)
				{
					throw new ArgumentException("List of monthly temperatures is empty");
				}

				return averageTemperature = MonthlyTemperatures.Average();
			}
		}
	}
}
