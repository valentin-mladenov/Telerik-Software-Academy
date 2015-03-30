using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//* 
//Write a program that reads a number
//N and generates and prints all the
//permutations of the numbers [1 … N].
//Example: n = 3  {1, 2, 3}, {1, 3, 2},
//{2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}


class All_Permutations
{
    static void Swap(ref int first, ref int second)
    {
        int temp = first;
        first = second;
        second = temp;
    }

    static void Permutation(int[] array, int current, int lenght)
    {
        if (current == lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = current; i <= lenght; i++)
            {
                Swap(ref array[i], ref array[current]);
                Permutation(array, current + 1, lenght);
                Swap(ref array[i], ref array[current]);
            }
        }
    }

    static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());
        int[] arrayOfNumbers = new int[numberN];

        for (int i = 1; i <= numberN; i++)
        {
            arrayOfNumbers[i - 1] = i;
        }

        Permutation(arrayOfNumbers, 0, arrayOfNumbers.Length - 1);
    }
}