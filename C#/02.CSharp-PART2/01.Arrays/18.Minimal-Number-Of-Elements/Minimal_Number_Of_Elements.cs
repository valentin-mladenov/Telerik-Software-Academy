using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//*
//Write a program that reads an array
//of integers and removes from it a minimal
//number of elements in such way that the
//remaining array is sorted in increasing
//order. Print the remaining sorted array.
//Example:
//{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}


class Minimal_Number_Of_Elements
{
    static void Main()
    {
        Console.Write("Enater size of Array: ");
        int numberN = int.Parse(Console.ReadLine());

        List<int> arrayN = new List<int>(numberN);

        for (int i = 0; i < numberN; i++)
        {
            Console.Write("Array [{0}] = ", i);
            arrayN.Add(int.Parse(Console.ReadLine()));
        }

        int length = (2 << arrayN.Count - 1) - 1;
        int counter = 0;
        int maxRepeaterCount = -1;
        int lastRepeaterCount = int.MinValue;
        int index = 0;
        int lastIndiex = 0;
        int currentNumber = int.MinValue;
        List<int> intTempList = new List<int>();
        List<int> numbersList = new List<int>();

        for (int i = 1; i < (length-1); i++)
        {
            currentNumber = int.MinValue;

            for (int j = 0; j < arrayN.Count; j++)
            {
                int mask = 1 << j;
                int nAndMask = mask & i;
                int bit = nAndMask >> j;

                if (bit==1)
                {
                    if (arrayN[j] >= currentNumber)
                    {
                        counter++;
                        intTempList.Add(arrayN[j]);
                        if (maxRepeaterCount<counter)
                        {
                            maxRepeaterCount = counter;
                            index = j - 1;
                        }
                    }
                    else if (arrayN[j] < currentNumber)
                    {
                        if (maxRepeaterCount< counter)
                        {
                            maxRepeaterCount = counter;
                            index = j - 1;
                        }
                    counter = 0;
                    }
                currentNumber =arrayN[j];    
                }
            }
            if (lastRepeaterCount < maxRepeaterCount)
            {
                lastRepeaterCount = maxRepeaterCount;
                lastIndiex = index;
                numbersList = new List<int>(intTempList);
                intTempList = new List<int>();
                counter = 0;
            }
            else
            {
                intTempList = new List<int>();
                counter = 0;
            }
        }

        Console.WriteLine("Original Array:");
        foreach (var number in arrayN)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 30));

        Console.WriteLine("Longest increasing order is: ");
        foreach (var item in numbersList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}