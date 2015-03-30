using System;

           //Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
           // След хиляди мъки.... дано поне е вярно!? :)

class Calculate_The_Sum_In_Float
{
    static void Main()
    {
        Console.WriteLine("Enter count: 1.");
        decimal count = decimal.Parse(Console.ReadLine());
        decimal firstCount = count;
        decimal secondCount = 2M;
        decimal result = 0M;
        decimal sign = 1M;
        decimal firstCountPoint = 1M / firstCount;
        decimal secondCountPoint = 1M / secondCount;

        for (decimal i = 3; i <= 200; i++)
        {
            result = firstCountPoint + secondCountPoint;
            Console.WriteLine("Sum = {0:0.000}", result);
            sign = -sign;
            secondCountPoint = (1M / i) * sign;
            firstCountPoint = result;
        }
    }
}