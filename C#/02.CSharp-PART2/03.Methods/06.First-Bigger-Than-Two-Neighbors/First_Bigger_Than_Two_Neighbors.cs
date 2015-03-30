using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method that returns the index
//of the first element in array that is
//bigger than its neighbors, or -1, if
//there’s no such element.
//Use the method from the previous exercise.


class First_Bigger_Than_Two_Neighbors
{
    static int[] Array(int arrLeng)
    {
        int[] count = new int[arrLeng];

        for (int i = 0; i < count.Length; i++)
        {
            count[i] = int.Parse(Console.ReadLine());
        }
        return count;
    }

    static int BiggerOrNot(int[] array)
    {
        int bigger = -1;

        for (int i = 1; i < array.Length-1; i++)
        {            
            if ((array[i] > array[i - 1]) && (array[i] > array[i + 1]))
            {
                bigger = i;
                break;
            }
        }
        return bigger;
    }

    static void Main()
    {
        Console.Write("Enter how long the array is:");
        int arrayLength = int.Parse(Console.ReadLine());

        int[] array = Array(arrayLength);

        int bigger = BiggerOrNot(array);

        if (bigger != -1)
        {
            Console.WriteLine("The number at position {0} is bigger then it's two neighbors.", bigger);
        }
        else
        {
            Console.WriteLine("There is no bigger number than it's two neighbors.");
        }
    }
}