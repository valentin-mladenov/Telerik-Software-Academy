using System;

//Write a program that calculates the greatest common divisor (GCD)
//of given two numbers. Use the Euclidean algorithm (find it in Internet).


class Greatest_Common_Divisor
{
    static void Main()
    {
        Console.WriteLine("Calculate the greatest common divisor (GCD) for given N and X:");
        Console.Write("Please enter a number N:");
        int numberN = int.Parse(Console.ReadLine());

        Console.Write("Please enter a number X:");
        int numberX = int.Parse(Console.ReadLine());

        int absNminusX = Math.Abs(numberN - numberX);
        int minValueNX = Math.Min(numberX, numberN);
        int numberGCD = 0;

        for (int i = 1; i <= absNminusX; i++)
        {
            if (minValueNX % i == 0 && absNminusX % i == 0)
            {
                numberGCD = i;
            }
        }
        Console.WriteLine("GCD({0},{1}) = {2}.", numberN, numberX, numberGCD);
    }
}