// Modify the previous program to skip duplicates:
// n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

using System;

internal class CombinationNoDuplicates
{
    private static void Main()
    {
        var number = 4;
        var length = 3;
        var array = new int[length];

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
            for (int i = start; i < number; i++)
            {
                array[index] = i;
                Duplication(number + 1, index + 1, i + 1, array);
            }
        }
    }
}