using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds in given
//array of integers a sequence of given
//sum S (if present). Example:
//{4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}

class SumS_In_Array
{
    static void Main()
    {
        Console.Write("Enater size of Array: ");
        int numberArray = int.Parse(Console.ReadLine());
        Console.Write("Enater sum S: ");
        int sumS = int.Parse(Console.ReadLine());

        int[] array = new int[numberArray];

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Array [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int result = 0;
        int count = 0;
        int currentMaxResult = 0;
        int countTemp = 0;

        for (int i = 0; i < array.Length - 1; i++)
        {
            result += array[i];
            count = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                result += array[j];
                countTemp = j;

                if (result > sumS)
                {
                    result = 0;
                        break;
                }
                else if (result == sumS)
                {
                    currentMaxResult++;
                    for (int k = count; k <= countTemp; k++)
                    {
                        Console.Write(array[k] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        Console.WriteLine("There are {0} sequences in array with sum {1}!", currentMaxResult, sumS);
    }
}