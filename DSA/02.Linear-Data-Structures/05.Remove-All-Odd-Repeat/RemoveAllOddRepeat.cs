// Write a program that removes from given sequence all numbers
// that occur odd number of times. Example:
// {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}

namespace _06.Remove_All_Odd_Repeat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RemoveAllOddRepeat
    {
        static void Main()
        {
            // Using only linear data structs, it will be faster with Dictionary
            List<int> oddCountIntsToRemove = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            List<int> sortedInts = oddCountIntsToRemove.ToList();
            sortedInts.Sort();

            Stack<int> onlyOddCountInts = new Stack<int>();
            bool IsOdd = true;

            for (int i = 0; i < sortedInts.Count-1; i++)
            {
                if (sortedInts[i] == sortedInts[i + 1])
                {
                    IsOdd = !IsOdd;
                }
                else
                {
                    if (IsOdd)
                    {
                        onlyOddCountInts.Push(sortedInts[i]);
                    }
                    else
                    {
                        IsOdd = true;
                    }
                }
            }

            while (onlyOddCountInts.Count!=0)
            {
                int intToRemove = onlyOddCountInts.Pop();

                oddCountIntsToRemove.RemoveAll(i => i == intToRemove);
            }

            Console.WriteLine(string.Join(", ", oddCountIntsToRemove));
        }
    }
}
