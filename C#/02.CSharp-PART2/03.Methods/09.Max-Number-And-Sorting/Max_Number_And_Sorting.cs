using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that return the
//maximal element in a portion of
//array of integers starting at
//given index. Using it write
//another method that sorts an
//array in ascending / descending order.

class Max_Number_And_Sorting
{
    static int[] ArrayInput(int arrLeng)
    {
        int[] count = new int[arrLeng];

        for (int i = 0; i < count.Length; i++)
        {
            count[i] = int.Parse(Console.ReadLine());
        }
        return count;
    }

    static int MaxNumberInPortionOfArray(int[] array, int start)
    {
        int maxNumber = 0;

        for (int i = start; i < array.Length; i++)
        {
            if (array[i] > maxNumber)
            {
                maxNumber = array[i];
            }
        }
        Console.WriteLine("Max number after index {0} is {1}.", start, maxNumber);
        return maxNumber;
    }

    static int[] Sorting(int[] array)
    {
        int min, temp;

        for (int i = 0; i < array.Length - 1; i++)
        {
            min = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }

            temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
        string finishAsc = string.Join(", ", array);
        Console.WriteLine("Array sorted in ascending order: {0}", finishAsc);

        Array.Reverse(array);
        string finishDsc = string.Join(", ", array);
        Console.WriteLine("Array sorted in descending order: {0}", finishDsc);

        return array;
    }

    static void Main()
    {
        Console.Write("Enter how long the array is:");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.Write("Enter from where is the start for search of maximal integer:");
        int maxInt = int.Parse(Console.ReadLine());

        if (maxInt > arrayLength)
        {
            Console.WriteLine("The start position is bigger then lenght of the array. Try again.");
            Main();
        }

        int[] array = ArrayInput(arrayLength);

        int maxNumber = MaxNumberInPortionOfArray(array, maxInt);

        int[] sorting = Sorting(array);
    }
}