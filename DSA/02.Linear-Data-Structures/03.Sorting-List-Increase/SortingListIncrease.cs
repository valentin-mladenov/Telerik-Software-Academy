// Write a program that reads a sequence of integers (List<int>)
// ending with an empty line and sorts them in an increasing order.

namespace _03.Sorting_List_Increase
{
    using System;
    using System.Collections.Generic;

    class SortingListIncrease
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var inputList = new List<int>();

            while (input != string.Empty)
            {
                int number = int.Parse(input);
                inputList.Add(number);

                input = Console.ReadLine();
            }

            inputList.Sort();

            Console.WriteLine(string.Join(", ",inputList));
        }
    }
}
