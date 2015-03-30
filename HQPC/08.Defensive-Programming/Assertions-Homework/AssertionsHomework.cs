using System;
using System.Diagnostics;
using System.Linq;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
		Debug.Assert(arr != null, "Array is null.");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

		// sort Assert
		for (int i = 0; i < arr.Length - 1; i++)
		{
			Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "Array not sorted");
		}
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
		Debug.Assert(arr != null, "Array is null.");
		Debug.Assert(startIndex >= 0, "Invalid Index position, must be >=0.");
		Debug.Assert(endIndex <= arr.Length - 1, "End index can't be higher than array's length.");
		Debug.Assert(startIndex <= endIndex, "Start index can't be higher than end index.");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

		for (int i = startIndex + 1; i < endIndex; i++)
			{
				int compare = arr[i].CompareTo(arr[minElementIndex]);
				Debug.Assert(compare <= 0, "The index " + minElementIndex + " is not the min element index.");
			}
		
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
		Debug.Assert(arr != null, "Array is null.");
		Debug.Assert(value != null, "Value is null.");

		// Is array sorted
		for (int i = 0; i < arr.Length - 1; i++)
		{
			Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "Array not sorted");
		}

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
		Debug.Assert(arr != null, "Array is null.");
		Debug.Assert(value != null, "Value is null.");
		Debug.Assert(startIndex >= 0, "Invalid start index " + startIndex + " position, must be >= 0.");
		Debug.Assert(endIndex >= 0, "Invalid end index " + endIndex + " position, must be >= 0.");
		Debug.Assert(endIndex <= arr.Length - 1, "End index can't be higher than array's length.");
		Debug.Assert(startIndex <= endIndex, "Start index can't be higher than end index.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
