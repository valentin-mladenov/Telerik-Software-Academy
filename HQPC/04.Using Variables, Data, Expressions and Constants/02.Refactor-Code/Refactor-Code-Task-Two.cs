using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Refactor_Code
{
	class Refactor_Code_Task_Two
	{
		//Added method
		//Not very slick written method, but if you have to change the output. You can do it only from here. 
		public static void Print(double content)
		{
			Console.WriteLine(content);
		}

		//Code split in methods feels mode correct.
		public static void PrintMax(double[] arr, int count)
		{
			// it was not set, now everything is bigger than MinValue.
			double max = double.MinValue;
			for (int i = 0; i < count; i++)
			{
				if (arr[i] > max)
				{
					max = arr[i];
				}
			}
			Print(max);
		}

		public static void PrintMin(double[] arr, int count)
		{
			//I assign new varible "min", as uesed "max", now everything is smaller than MaxValue.
			double min = double.MaxValue;
			for (int i = 0; i < count; i++)
			{
				if (arr[i] < min)
				{
					min = arr[i];
				}
			}
			Print(min);
		}

		public static void PrintAverage(double[] arr, int count)
		{
			//I assign new varible "sum", as uesed name "tmp", set to Zero.
			double sum = 0;
			for (int i = 0; i < count; i++)
			{
				sum += arr[i];
			}
			double average = sum / count; //No explain needed.
			Print(average);
		}

		public void PrintStatistics(double[] arr, int count)
		{
			PrintMax(arr, count);

			PrintMin(arr, count);

			PrintAverage(arr, count);
		}
	}
}
