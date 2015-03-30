//* Write a program to compare the performance
//of insertion sort, selection sort, quicksort
//for int, double and string values. Check also
//the following cases: random values, sorted values,
//values sorted in reversed order.


namespace _04.SelectionSort_QuickSort_InsertionSort
{
	using System;
	using System.Linq;

	class SelectionSortQuickSortInsertionSort
	{		
		static void Main(string[] args)
		{
			decimal[] arrayTestSelection = new decimal[5] { 5.142m, 0.1346m, 3.41m, 2.3145m, 8456.23456m };
			decimal[] arrayTestQuick = new decimal[5] { 5.23456m, 6234.568m, 3234.43m, 0.23456m, 8.1235m };
			decimal[] arrayTestInsertion = new decimal[5] { 5245.35m, 56.146m, 23.243m, 2.459m, 0.12348m };

			string[] arrayStrSelection = new string[5] { "fghj", "hrh6", "shts3", "seyth2", "8gh" };
			string[] arrayStrQuick = new string[5] { "5dyjd", "rggth6", "dyjd3", "hgsr2", "djyd8" };
			string[] arrayStrInsertion = new string[5] { "str5", "6lip", "shh3", "djyd2", "dyjd8" };

			int[] arrayIntSelection = new int[5] { 57, 36, 373, 32, 184 };
			int[] arrayIntQuick = new int[5] { 53, 776, 3451, 452, 1418 };
			int[] arrayIntInsertion = new int[5] { 5, 68675, 13, 25, 80 };

			double[] arrayDoubleSelection = new double[5] { 5.142, 0.12346, 3.4521, 2.3145, 83456.23456 };
			double[] arrayDoubleQuick = new double[5] { 5.23456, 6234.5678, 31234.43, 0.234562, 8.12345 };
			double[] arrayDoubleInsertion = new double[5] { 52455.35, 56.146, 23.2453, 2.4509, 0.123458 };

			Console.WriteLine("TEST no matter what value type i use it is always slow, coz for the dynamic cast.");
			Sort.Compairer(arrayTestSelection, arrayTestQuick, arrayTestInsertion);
			Console.WriteLine();

			Console.WriteLine("DOUBLE");
			Sort.Compairer(arrayDoubleSelection, arrayDoubleQuick, arrayDoubleInsertion);
			Console.WriteLine();

			Console.WriteLine("INTEGER");
			Sort.Compairer(arrayIntSelection, arrayIntQuick, arrayIntInsertion);
			Console.WriteLine();

			Console.WriteLine("STRING");
			Sort.Compairer(arrayStrSelection, arrayStrQuick, arrayStrInsertion);
			Console.WriteLine();
		}
	}
}
