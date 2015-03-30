// *
// We are given numbers N and M and the following operations:
// N = N+1
// N = N+2
// N = N*2
// Write a program that finds the shortest sequence of operations
// from the list above that starts from N and finishes in M.
// Hint: use a queue.
// Example: N = 5, M = 16
// Sequence: 5  6  8  16

namespace _10.Shortest_N_M_Sequence
{
    using System;
    using System.Collections.Generic;

    internal class ShortestNMSequence
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter M: ");
            int m = int.Parse(Console.ReadLine());

            // int n = 5;
            // int m = 16;

            Queue<int> steps = new Queue<int>();

            int result = n;
            steps.Enqueue(result);
            byte operation = 1;

            while (result < m)
            {
                if (operation == 1)
                {
                    result ++;
                    operation = 2;
                }
                else if (operation == 2)
                {
                    result = result + 2;
                    operation = 0;
                }
                else
                {
                    result = result*2;
                    operation = 1;
                }

                steps.Enqueue(result);
            }

            Console.WriteLine(string.Join(", ", steps));
        }
    }
}