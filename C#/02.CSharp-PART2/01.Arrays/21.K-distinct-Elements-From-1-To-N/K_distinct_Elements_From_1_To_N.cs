using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads two numbers N
//and K and generates all the combinations
//of K distinct elements from the set [1..N].

//Example:
//N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5},
//{2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}.


class K_distinct_Elements_From_1_To_N
{
        static int numberN = int.Parse(Console.ReadLine());
        static int numberK = int.Parse(Console.ReadLine());

    static void Combinations(int[] array, int index, int currentNumber)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }

        else
        {
            for (int i = currentNumber; i <= numberN; i++)
            {
                array[index]= i;
                Combinations(array, index +1, i + 1);
            }
        }
    }

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        int[] arrayK = new int[numberK];
        Combinations(arrayK, 0, 1);
    }
}