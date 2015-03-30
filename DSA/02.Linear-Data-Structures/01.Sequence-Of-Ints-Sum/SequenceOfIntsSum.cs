// Write a program that reads from the console a sequence of positive
// integer numbers. The sequence ends when empty line is entered.
// Calculate and print the sum and average of the elements
// of the sequence. Keep the sequence in List<int>.

namespace _01.Sequence_Of_Ints_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SequenceOfIntsSum
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

            int result = inputList.Sum();

            Console.WriteLine(result);
        }
    }
}
