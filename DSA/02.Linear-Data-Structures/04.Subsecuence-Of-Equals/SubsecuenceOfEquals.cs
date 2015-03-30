// Write a method that finds the longest subsequence of equal numbers
// in given List<int> and returns the result as new List<int>.
// Write a program to test whether the method works correctly.

namespace _04.Subsecuence_Of_Equals
{
    using System;
    using System.Collections.Generic;

    internal class SubsecuenceOfEquals
    {
        private static void Main()
        {
            var list = new List<int>()
            {
                1,
                2,
                2,
                3,
                2,
                3,
                4,
                4,
                5
            };

            var subseqList = new List<int>();
            int result = 1;
            int count = 0;
            int currentMaxResult = 0;
            int countTemp = 0;

            for (int i = count; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    result++;
                    count = list[i];
                }
                else
                {
                    if (currentMaxResult <= result)
                    {
                        currentMaxResult = result;
                        countTemp = list[i];
                        result = 1;
                    }
                }
            }

            if (currentMaxResult <= result)
            {
                for (int i = 0; i < result; i++)
                {
                    subseqList.Add(count);
                }

                Console.WriteLine(string.Join(", ", subseqList));
            }
            else
            {
                for (int i = 0; i < currentMaxResult; i++)
                {
                    subseqList.Add(countTemp);
                }

                Console.WriteLine(string.Join(", ", subseqList));
            }
        }
    }
}