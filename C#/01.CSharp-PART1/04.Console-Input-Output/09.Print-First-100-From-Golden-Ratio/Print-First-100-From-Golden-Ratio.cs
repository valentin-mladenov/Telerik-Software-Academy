using System;

                //Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

class Print_First_100_From_Golden_Ratio
{
    static void Main()
    {
        Console.WriteLine("Enter the first number from the sequence of Fibonacci(which is 0). :)");
        byte count = byte.Parse(Console.ReadLine());

        decimal firstCount = count;
        decimal secondCount = 1;
        decimal result = 0;

        for (int i = 1; i <= 100; i++)
        {
            result = firstCount + secondCount;
            Console.WriteLine(result);
            firstCount = secondCount;
            secondCount = result;
        }
    }
}
