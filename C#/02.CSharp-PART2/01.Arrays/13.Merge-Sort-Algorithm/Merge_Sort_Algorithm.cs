using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//* 
//Write a program that sorts an array
//of integers using the merge sort
//algorithm (find it in Wikipedia).


class Merge_Sort_Algorithm
{
    static int[] MergerArrays(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];

        int leftIncrease = 0;
        int rightIncrease = 0;

        for (int i = 0; i < result.Length; i++)
        {
            if (rightIncrease == right.Length || ((leftIncrease < left.Length) && (left[leftIncrease] <= right[rightIncrease])))
            {
                result[i] = left[leftIncrease];
                leftIncrease++;
            }
            else if (leftIncrease == left.Length || ((rightIncrease < right.Length) && (right[rightIncrease] <= left[leftIncrease])))
	        {
		        result[i] = right[rightIncrease];
                rightIncrease++;
	        }
        }
        return result;
    }

    static int[] MergeSort(int[] array)
    {
        if (array.Length <= 1)
        {
            return array;
        }

        int middle = array.Length / 2;
        int[] leftArray = new int[middle];
        int[] rightArray = new int[array.Length - middle];

        for (int i = 0; i < middle; i++)
        {
            leftArray[i] = array[i];
        }

        for (int i = middle, j = 0; i < array.Length; j++, i++)
        {
            rightArray[j] = array[i];
        }

        leftArray = MergeSort(leftArray);
        rightArray = MergeSort(rightArray);

        return MergerArrays(leftArray, rightArray);
    }

    static void Main()
    {
        Console.Write("Enater size of Array: ");
        int number = int.Parse(Console.ReadLine());

        int[] arrayIntegers = new int[number];

        for (int i = 0; i < arrayIntegers.Length; i++)
        {
            Console.Write("Array [{0}] = ", i);
            arrayIntegers[i] = int.Parse(Console.ReadLine());
        }

        int[] sortedArray = MergeSort(arrayIntegers);

        for (int i = 0; i < sortedArray.Length; i++)
        {
            Console.Write(sortedArray[i] + " ");
        }
        Console.WriteLine();
    }
}