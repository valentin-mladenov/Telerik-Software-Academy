// Write a recursive program for generating and printing all the
// combinations with duplicates of k elements from n-element set. 
// Example: n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

using System;

internal class CombinationWithDuplicate
{
    public static int maxNum;

    public static void Main()
    {
        var number = 5;
        var length = 3;
        var array = new int[length];
        maxNum = number;

        Duplication(number, 0, 1, array);
    }

    public static void Duplication(int number, int index, int start, int[] array)
    {
        if (index == array.Length)
        {
            Console.WriteLine(string.Join(", ", array));
        }
        else
        {
            for (int i = start; i <= number; i++)
            {
                array[index] = i;
                if (number == maxNum)
                {
                    Duplication(number, index + 1, i, array);
                }
                else
                {
                    Duplication(number + 1, index + 1, i, array);
                }
            }
        }
    }
}