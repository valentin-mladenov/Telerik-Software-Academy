//Write a recursive program that simulates the execution of
// n nested loops from 1 to n.

using System;
using System.Linq;

internal class NestedLoops
{
    public static void Main()
    {
        var number = 3;
        var array = new int[number];
        Nesting(number, array);
    }

    public static void Nesting(int number, int[] array)
    {
        if (number == 0)
        {
            var arr = array.Reverse();
            Console.WriteLine(string.Join(", ", arr));
        }
        else
        {
            for (int i = 1; i <= array.Length; i++)
            {
                array[number - 1] = i;
                Nesting(number - 1, array);
            }
        }
    }
}