using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that counts how many
//times given number appears in given
//array. Write a test program to check
//if the method is working correctly.


class Count_Integer_In_Array
{
    static int Integer(int integerCount, int[] array)
    {
        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (integerCount == array[i])
            {
                count++;
            }
        }
        return count;
    }

    static int[] Array(int arrLeng)
    {
        int[] count = new int[arrLeng];

        for (int i = 0; i < count.Length; i++)
        {
            count[i] = int.Parse(Console.ReadLine());
        }
        return count;
    }

    static void Main()
    {
        Console.Write("Enter how long the array is:");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.Write("Enter an integer to count:");
        int integerCount = int.Parse(Console.ReadLine());

        int[] array = Array(arrayLength);

        int count = Integer(integerCount, array);


        Console.WriteLine("The integer {0} repeats {1} times.", integerCount, count);
    }
}