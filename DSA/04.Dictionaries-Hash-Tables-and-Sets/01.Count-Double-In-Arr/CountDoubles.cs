// Write a program that counts in a given array of double values the number
// of occurrences of each value. Use Dictionary<TKey,TValue>.
// Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
// -2.5  2 times
// 3  4 times
// 4  3 times

namespace _01.Count_Double_In_Arr
{
    using System;
    using System.Collections.Generic;

    internal class CountDoubles
    {
        private static void Main()
        {
            double[] array = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var dictionary = new Dictionary<double, int>();

            foreach (var member in array)
            {
                if (!dictionary.ContainsKey(member))
                {
                    dictionary.Add(member, 0);
                }

                dictionary[member]++;
            }

            foreach (var pair in dictionary)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value + "times.");
            }
        }
    }
}