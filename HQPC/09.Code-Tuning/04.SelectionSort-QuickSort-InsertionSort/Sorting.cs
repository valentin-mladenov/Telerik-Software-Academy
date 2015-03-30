namespace _04.SelectionSort_QuickSort_InsertionSort
{
	using System;
	using System.Diagnostics;
	using System.Linq;

	class Sort
	{
		public static void Compairer<T>(T[] selection, T[] quick, T[] insertion)
		{
			dynamic innerArray = selection;

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			SortingAlgorithms.SelectionSort(innerArray);
			stopwatch.Stop();
			Console.WriteLine("Selection Sort time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");

			innerArray = quick;
			stopwatch.Start();
			SortingAlgorithms.QuickSort(innerArray, 0, innerArray.Length - 1);
			stopwatch.Stop();
			Console.WriteLine("Quick Sort time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");

			innerArray = insertion;
			stopwatch.Start();
			SortingAlgorithms.InsertionSort(innerArray);
			stopwatch.Stop();
			Console.WriteLine("Insertion Sort time: " + stopwatch.Elapsed.TotalMilliseconds + " ms.");
		}

	}
}
