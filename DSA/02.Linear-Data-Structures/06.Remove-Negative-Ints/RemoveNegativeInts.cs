// Write a program that removes from given sequence all negative numbers.

namespace _06.Remove_Negative_Ints
{
    using System;
    using System.Collections.Generic;

    class RemoveNegativeInts
    {
        static void Main()
        {
            var input = Console.ReadLine();
            
            var inputStack = new Queue<int>();

            while (input != string.Empty)
            {
                int number = int.Parse(input);

                    inputStack.Enqueue(number);

                input = Console.ReadLine();
            }

            // The check for positivity can be done in input
            // but for the sequence. :)
            IList<int> positiveInts = new List<int>();
            while (inputStack.Count!=0)
            {
                int result = inputStack.Dequeue();
                if (result>=0)
                {
                    positiveInts.Add(result);
                }
            }

            Console.WriteLine(string.Join(", ",positiveInts));
        }
    }
}
