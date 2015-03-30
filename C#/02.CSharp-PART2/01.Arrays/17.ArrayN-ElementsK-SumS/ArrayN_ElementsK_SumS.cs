using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//*
//Write a program that reads three integer
//numbers N, K and S and an array of N
//elements from the console.Find in the array
//a subset of K elements that have sum S
//or indicate about its absence.


class ArrayN_ElementsK_SumS
{
    static void Main()
    {
        Console.Write("Enater size of Array: ");
        long arrayN = long.Parse(Console.ReadLine());
        Console.Write("Enater sum S: ");
        long sumS = long.Parse(Console.ReadLine());
        Console.Write("Enater subset K: ");
        long subsetK = long.Parse(Console.ReadLine());

        long[] array = new long[arrayN];
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
            int lenghtCount = 0;

            for (int j = 0; j < array.Length; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    checkSum = checkSum + array[j];
                    subset = subset + " " + array[j];
                    lenghtCount++;
                }
            }
            if (checkSum == sumS && lenghtCount == subsetK)
            {
                Console.Write("Yes. Sum S: {0}. ", sumS);
                counter++;
                Console.WriteLine("Subset: {0}", subset);
            }
            else
            {
                Console.WriteLine("No.");
            }
        }
        Console.WriteLine(counter);
    }
}