using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//*
//We are given an array of integers and
//a number S. Write a program to find if
//there exists a subset of the elements
//of the array that has a sum S. Example:
//arr={2, 1, 2, 4, 3, 5, 2, 6},
//S=14  yes (1+2+5+6)


class SubstS_In_ArrayN
{
    static void Main()
    {
        Console.Write("Enater size of Array: ");
        long numberArray = long.Parse(Console.ReadLine());
        Console.Write("Enater sum S: ");
        long sumS = long.Parse(Console.ReadLine());

        long[] array = new long[numberArray];
        long maxSubSets = (2 << array.Length - 1) - 1;

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Array [{0}] = ", i);
            array[i] = long.Parse(Console.ReadLine());
        }

        int counter = 0;
        string subset = "";

        for (int i = 1; i < maxSubSets; i++)
        {
            subset = "";
            long checkSum = 0;

            for (int j = 0; j < array.Length; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit==1)
                {
                    checkSum = checkSum + array[j];
                    subset = subset + " " + array[j];
                }
            }
            if (checkSum == sumS)
            {
                Console.Write("Yes. Sum S: {0}. ", sumS);
                counter++;
                Console.WriteLine("Subset: {{0}}", subset);
            }
            else
            {
                Console.WriteLine("No.");
            }
        }
        Console.WriteLine(counter);
    }
}