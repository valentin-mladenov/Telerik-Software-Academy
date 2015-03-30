using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that sorts an array
//of strings using the quick sort
//algorithm (find it in Wikipedia).

class Quick_Sort_Algorithm
{
    public static void QuickSort(string[] sortArray, int leftIndex, int rightIndex)
    {

        int leftPointer = leftIndex;
        int rightPointer = rightIndex;

        string middle = sortArray[(leftIndex + rightIndex)/2];
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
            if (leftPointer<=rightPointer)
	        {
                string swap = sortArray[leftPointer];
                sortArray[leftPointer] = sortArray[rightPointer];
                sortArray[rightPointer] = swap;

                leftPointer++;
                rightPointer--;
	        }
        }

        if (leftIndex < rightPointer)
	    {
            QuickSort(sortArray, leftIndex, rightPointer);
	    }
        if (leftPointer < rightIndex)
	    {
            QuickSort(sortArray, leftPointer, rightIndex);
	    }
    }

    static void Main()
    {
        Console.Write("Enter a number of strings in a Array: ");
        int number = int.Parse(Console.ReadLine());

        string[] array = new string[number];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Console.ReadLine();
        }

        QuickSort(array, 0, array.Length - 1);

        string sortedArray = string.Join(", ", array);
        Console.WriteLine(sortedArray);
    }
}