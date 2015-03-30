// *
// The majorant of an array of size N is a value that occurs
// in it at least N/2 + 1 times. Write a program to find the
// majorant of given array (if exists). Example:
// {2, 2, 3, 3, 2, 3, 4, 3, 3}  3

namespace _08.The_Majorant_In_Array
{
    using System;
    using System.Collections.Generic;

    internal class TheMajorantInArray
    {
        private static void Main()
        {
            var integerList = new List<int> {2, 2, 3, 3, 2, 3, 4, 3, 3};
            integerList.Sort();

            int count = 1;
            int currentInt = 0;
            int majorant = integerList.Count/2 + 1;
            for (int i = 0; i < integerList.Count - 1; i++)
            {
                if (integerList[i] == integerList[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count >= majorant)
                    {
                        currentInt = integerList[i];
                        break;
                    }

                    count = 1;
                }
            }
            if (count >= majorant)
            {
                Console.WriteLine("{0} is the majorant repeates {1} times.",
                    currentInt, count);
            }
            else
            {
                Console.WriteLine("No majorant.");
            }
        }
    }
}