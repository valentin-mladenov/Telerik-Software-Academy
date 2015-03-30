// Write a program for generating and printing all subsets of
// k strings from given set of strings.
// Example: s = {test, rock, fun}, k=2
// (test rock),  (test fun),  (rock fun)

namespace _06.All_Subsets_Of_Strings
{
    using System;

    public class AllSubsetsOfStrings
    {
        public static string[] arrayStr = { "hi", "a", "b" };

        public static void Main()
        {
            var length = 2;
            var printArr = new string[length];
            Duplication(0, 0, printArr);
        }

        public static void Duplication(int index, int start, string[] array)
        {
            if (index == array.Length)
            {
                Console.WriteLine(string.Join(", ", array));
            }
            else
            {
                for (int i = start; i < arrayStr.Length; i++)
                {
                    array[index] = arrayStr[i];
                    Duplication(index + 1, i + 1, array);
                }
            }
        }
    }
}