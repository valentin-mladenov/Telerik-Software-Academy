using System;
using System.Numerics;

//Write a program that, for a given two integer numbers N and X,
//calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/X^N.


class Calculate_Sum_Fact_of_Two_Integer_N_And_X
{
    static void Main()
    {
        Console.WriteLine("Calculate sum S = 1 + 1!/X + 2!/X2 + … + N!/X^N for given N and X (X!=0):");
        Console.Write("Please enter a number N:");
        double numberN = double.Parse(Console.ReadLine());

        Console.Write("Please enter a number X:");
        double numberX = double.Parse(Console.ReadLine());

        double sumFactorialNFactorialX = 1;

        if (numberX != 0)
        {
            Console.Write("Sum:");
            for (double i = 1; i <= numberN; i++)
            {
                sumFactorialNFactorialX += i / Math.Pow(numberX, i);
            }
            Console.WriteLine(sumFactorialNFactorialX);
        }

        else
        {
            Console.WriteLine("Error!!! Incorect number X. X=0. Please try again.");
            Main();
        }
    }
}