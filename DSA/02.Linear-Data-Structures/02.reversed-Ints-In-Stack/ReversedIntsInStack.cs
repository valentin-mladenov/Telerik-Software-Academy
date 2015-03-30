// Write a program that reads N integers from the console and 
// reverses them using a stack. Use the Stack<int> class.

namespace _02.reversed_Ints_In_Stack
{
    using System;
    using System.Collections.Generic;

    public class ReversedIntsInStack
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var stackedInts = new Stack<int>(n);

            for (int i = 0; i < n; i++)
            {
                stackedInts.Push(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < n-1; i++)
            {
                Console.Write(stackedInts.Pop() + ", ");
            }
            Console.WriteLine(stackedInts.Pop());
        }
    }
}
