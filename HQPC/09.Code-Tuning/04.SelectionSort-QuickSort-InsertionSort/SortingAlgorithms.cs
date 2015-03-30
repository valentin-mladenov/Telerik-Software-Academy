namespace _04.SelectionSort_QuickSort_InsertionSort
{
	using System;
	using System.Linq;

	class SortingAlgorithms
	{
		public static void SelectionSort<T>(T[] array)
			where T : IComparable
		{
			int min;
			dynamic inner;

			for (int i = 0; i < array.Length - 1; i++)
			{
				min = i;

				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[j].CompareTo(array[min]) < 0)
					{
						min = j;
					}
				}

				inner = array[i];
				array[i] = array[min];
				array[min] = inner;
			}
		}

		public static void QuickSort<T>(T[] sortArray, int left, int right)
			where T : IComparable
		{

			int leftPointer = left;
			int rightPointer = right;

			T middle = sortArray[(left + right) / 2];
			while (leftPointer <= rightPointer)
			{
				while (sortArray[leftPointer].CompareTo(middle) < 0)
				{
					leftPointer++;
				}
				while (sortArray[rightPointer].CompareTo(middle) > 0)
				{
					rightPointer--;
				}
				if (leftPointer <= rightPointer)
				{
					T swap = sortArray[leftPointer];
					sortArray[leftPointer] = sortArray[rightPointer];
					sortArray[rightPointer] = swap;

					leftPointer++;
					rightPointer--;
				}
			}

			// recursion
			if (left < rightPointer)
			{
				QuickSort(sortArray, left, rightPointer);
			}
			if (leftPointer < right)
			{
				QuickSort(sortArray, leftPointer, right);
			}

			//return sortArray;
		}

		public static void InsertionSort<T>(T[] array)
			where T : IComparable
		{
			int j;
			dynamic index;

			for (int i = 1; i < array.Length; i++)
			{
				index = array[i];
				j = i;

				while ((j > 0) && (array[j - 1].CompareTo(index) > 0))
				{
					array[j] = array[j - 1];
					j = j - 1;
				}

				array[j] = index;
			}
		}
	}
}
