// We are given the following sequence:
// S1 = N;
// S2 = S1 + 1;
// S3 = 2*S1 + 1;
// S4 = S1 + 2;
// S5 = S2 + 1;
// S6 = 2*S2 + 1;
// S7 = S2 + 2; ...
// Using the Queue<T> class write a program to print its first 50 members for given N.
// Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

namespace _09.First_50_Members
{
    using System;
    using System.Collections.Generic;

    internal class First50Members
    {
        private const int Repetirions = 50;

        private static void Main()
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            // int n = 2;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            for (int i = 1; i < Repetirions - 1; i++)
            {
                int result = queue.Dequeue();
                queue.Enqueue(result + 1);
                queue.Enqueue(2*result + 1);
                queue.Enqueue(result + 2);

                Console.Write(result + ", ");
            }

            Console.WriteLine(queue.Dequeue());
        }
    }
}