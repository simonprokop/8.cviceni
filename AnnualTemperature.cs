using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.cviceni
{
	class AnnualTemperature
	{
		private int year;
		private double maxTemperature;
		private double minTemperature;
		private double averageTemperature;

		public int Year
		{

			get { return year; }

			protected set
			{
				if (year < 0 || year > 2021)
				{ throw new ArgumentOutOfRangeException($" For {nameof(year)} have no temperatures!"); }

			}

		}
		public List<double> MonthlyTemperatures
		{ get; set; }

		public double MaxTemperature
		{
			get
			{
				if (MonthlyTemperatures.Count == 0)
				{
					throw new ArgumentException("List of monthly temperatures is empty");
				}

				return maxTemperature = MonthlyTemperatures.Max();
				/*foreach (double Temperature in MonthlyTemperatures)
				{
					if (Temperature > maxTemperature)
					{
						maxTemperature = Temperature;
					}
				}
				return maxTemperature;*/
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
				/*foreach (double Temperature in MonthlyTemperatures)
				{
					if (Temperature < minTemperature)
					{
						minTemperature = Temperature;
					}
				}
				return minTemperature;*/
			}
		}
		public double AverageTemperature
		{
			get { return averageTemperature = MonthlyTemperatures.Average(); }
		}


	}
}
