using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads two
//arrays from the console and
//compares them element by element.

class Compare_2_Arrays
{
    static void Main()
    {
        Console.WriteLine("Compare two arrays:");
        Console.Write("Enater size of Array 1: ");
        int size1 = int.Parse(Console.ReadLine());

        int[] array1 = new int [size1];

        for (int i = 0; i < size1; i++)
        {
            Console.Write("Array1 [{0}] = ", i);
            array1[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enater size of Array 2: ");
        int size2 = int.Parse(Console.ReadLine());

        int[] array2 = new int[size2];

        for (int i = 0; i < size2; i++)
        {
            Console.Write("Array2 [{0}] = ", i);
            array2[i] = int.Parse(Console.ReadLine());
        }

        if (size1 == size2)
        {
        }
        else if (size2> size1)
        {
            Console.WriteLine("Array 1 is smaller than Array 2. Using Array 1's length.");
        }
        else
        {
            Console.WriteLine("Array 2 is smaller than Array 1. Using Array 2's length.");
        }

        int minSize = Math.Min(size1, size2);

        for (int i = 0; i < minSize; i++)
        {
            if (array1[i] == array2[i])
            {
                Console.WriteLine("Array1 [{0}] = Array2 [{0}]", i);
            }
            else
            {
                Console.WriteLine("Array1 [{0}] != Array2 [{0}]", i);   
            }
        }
    }
}