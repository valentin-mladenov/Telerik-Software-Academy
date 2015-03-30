// Write a recursive program for generating and printing all ordered k-element
// subsets from n-element set (variations Vkn).
// Example: n=3, k=2, set = {hi, a, b} =>
// (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)

namespace _05.All_Variations_Of_Subsets
{
    using System;

    internal class AllVariationsOfSubsets
    {
        public static string[] arrayStr = { "hi", "a", "b" };

        public static void Main()
        {
            var length = 3;
            var printArr = new string[length];
            Duplication(0, printArr);
        }

        public static void Duplication(int index, string[] array)
        {
            if (index == array.Length)
            {
                Console.WriteLine(string.Join(", ", array));
            }
            else
            {
                for (int i = 0; i < arrayStr.Length; i++)
                {
                    array[index] = arrayStr[i];
                    Duplication(index + 1, array);
                }
            }
        }
    }
}