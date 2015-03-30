using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that finds the index
//of given element in a sorted array of
//integers by using the binary search
//algorithm (find it in Wikipedia).


class Binary_Search_Algorithm
{
    static int BinSearch(int[] array, int key)
    {
        Array.Sort(array);
        int iMax = array.Length - 1;
        int iMin = 0;
        int iMiddle = 0;
        while (iMax >= iMin)
        {
            iMiddle = (iMax + iMin) /2;
            if (array[iMiddle] < key)
            {
                iMin = iMiddle + 1;
            }
            else if (array[iMiddle] > key)
            {
                iMax = iMiddle - 1;
            }
            else
            {
                return iMiddle;
            }
        }
        return -1;
    }

    static void Main()
    {
        Console.Write("Enater size of Array: ");
        int number = int.Parse(Console.ReadLine());

        int[] array = new int[number];

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Array [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enater size of Key search: ");
        int key = int.Parse(Console.ReadLine());

        Console.WriteLine(BinSearch(array, key));
    }
}


//BinarySearch in List.

//List<string> l = new List<string>();
//l.Add("acorn");      // 0
//l.Add("apple");      // 1
//l.Add("banana");     // 2
//l.Add("cantaloupe"); // 3
//l.Add("lettuce");    // 4
//l.Add("onion");      // 5
//l.Add("peach");      // 6
//l.Add("pepper");     // 7
//l.Add("squash");     // 8
//l.Add("tangerine");  // 9

//// This returns the index of "peach".
//int i = l.BinarySearch("peach");
//Console.WriteLine(i);

//i = l.BinarySearch

//// This returns the index of "banana".
//i = l.BinarySearch("banana");
//Console.WriteLine(i);

//// This returns the index of "apple".
//i = l.BinarySearch("apple");
//Console.WriteLine(i);
