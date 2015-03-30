// Write a recursive program for generating and printing all permutations
// of the numbers 1, 2, ..., n for given integer number n. Example:
//n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}

using System;

internal class AllPermutationsOfN
{
    private static void Main()
    {
        var number = 4;
        var array = new int[number];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + 1;
        }

        Permutations(array, 0, number - 1);
    }

    private static void Permutations(int[] array, int currentNum, int length)
    {
        if (currentNum == length)
        {
            Console.WriteLine(string.Join(", ", array));
        }
        else
        {
            for (int i = currentNum; i < length + 1; i++)
            {
                Swapper(ref array[i], ref array[currentNum]);
                Permutations(array, currentNum + 1, length);
                Swapper(ref array[i], ref array[currentNum]);
            }
        }
    }

    private static void Swapper(ref int num1, ref int num2)
    {
        int inner = num1;
        num1 = num2;
        num2 = inner;
    }
}