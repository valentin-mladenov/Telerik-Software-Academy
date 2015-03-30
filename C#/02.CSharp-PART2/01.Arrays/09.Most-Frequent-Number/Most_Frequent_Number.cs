using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds the most
//frequent number in an array. Example:
//{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
//That was easy just combine "selection sort" and 2-nd task. :)


class Most_Frequent_Number
{
    static void Main()
    {
        Console.Write("How long the array is:");
        int number = int.Parse(Console.ReadLine());

        int[] array = new int[number];

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Array [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

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

        int result = 1;
        int count = 0;
        int currentMaxResult = 0;
        int countTemp = 0;

        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == array[i + 1])
            {
                result++;
                count = array[i];
            }
            else
            {
                if (currentMaxResult >= result)
                {
                }
                else
                {
                    currentMaxResult = result;
                    countTemp = array[i];
                    result = 1;
                }
            }
        }

        if (currentMaxResult <= result)
        {
            Console.WriteLine("Element: {0}, Repeats: {1} times.", count, result);
        }
        else
        {
            Console.WriteLine("Element: {0}, Repeats: {1} times.", countTemp, currentMaxResult);
        }
    }
}