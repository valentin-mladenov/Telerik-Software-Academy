using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that compares two 
//char arrays lexicographically 
//(letter by letter).


class Compare_2_Char_Arrays_Lexicographically
{
    static void Main()
    {
        Console.WriteLine("Compare two arrays:");
        Console.Write("Enater size of Array 1: ");
        int size1 = int.Parse(Console.ReadLine());

        char[] array1 = new char[size1];

        for (int i = 0; i < size1; i++)
        {
            Console.Write("Array1 [{0}] = ", i);
            array1[i] = char.Parse(Console.ReadLine());
        }

        Console.Write("Enater size of Array 2: ");
        int size2 = int.Parse(Console.ReadLine());

        char[] array2 = new char[size2];

        for (int i = 0; i < size2; i++)
        {
            Console.Write("Array2 [{0}] = ", i);
            array2[i] = char.Parse(Console.ReadLine());
        }

        if (size1 == size2)
        {
        }
        else if (size2 > size1)
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
