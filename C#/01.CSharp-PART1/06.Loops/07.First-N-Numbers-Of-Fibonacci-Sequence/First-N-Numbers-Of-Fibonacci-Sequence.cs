using System;

//Write a program that reads a number N and calculates the
//sum of the first N members of the sequence of Fibonacci: 
//0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
//Each member of the Fibonacci sequence (except the
//first two) is a sum of the previous two members.



class First_N_Numbers_Of_Fibonacci_Sequence
{
    static void Main()
    {
        Console.WriteLine("Calculate first N members of the sequence of Fibonacci:");
        Console.Write("Please enter a member N:");
        ulong memberN = ulong.Parse(Console.ReadLine());

        ulong firstN = 1;
        ulong secondN = 0;
        ulong thirdN = 0;
        ulong sumN = 0;

        for (ulong i = 1; i <= memberN; i++)
        {
            thirdN = firstN + secondN;
            firstN = secondN;
            secondN = thirdN;
            Console.WriteLine(i + ": " + thirdN);
            sumN += thirdN;
        }
        Console.WriteLine("The sum is: {0}", sumN);
    }
}