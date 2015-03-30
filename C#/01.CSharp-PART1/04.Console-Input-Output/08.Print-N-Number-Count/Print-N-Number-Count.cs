using System;

                //Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.

class Print_N_Number_Count
{
    static void Main()
    {
        Console.WriteLine("Enter integer number N:");
        int count = int.Parse(Console.ReadLine());
        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine("Count:{0}",i);
        }
    }
}