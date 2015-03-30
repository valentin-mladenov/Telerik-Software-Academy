// Write a program that finds in given array of integers
// (all belonging to the range [0..1000]) how many times each of them occurs.
// Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
// 2  2 times, 3  4 times, 4  3 times

namespace _07.Repetition_Of_Integers
{
    using System;
    using System.Collections.Generic;

    internal class RepetitionOfIntegers
    {
        private static void Main()
        {
            // Dictionary is what we want here, only linear used anyway.
            // Actually create it.
            var integerList = new List<int> { 3, 4, 4, 2, 3, 3, 4, 3, 2, 1 };
            integerList.Sort();

            Stack<int> integersStack = new Stack<int>();
            Stack<int> countIntsStack = new Stack<int>();

            int count = 1;

            for (int i = 0; i < integerList.Count - 1; i++)
            {
                if (integerList[i] == integerList[i + 1])
                {
                    count++;
                }
                else
                {
                    integersStack.Push(integerList[i]);
                    countIntsStack.Push(count);
                    count = 1;
                }
            }
            integersStack.Push(integerList[integerList.Count - 1]);
            countIntsStack.Push(count);

            while (countIntsStack.Count != 0)
            {
                int countInt = countIntsStack.Pop();
                int integer = integersStack.Pop();

                Console.WriteLine("{0} repeates {1} times.", integer, countInt);
            }
        }
    }
}