using System;

                //Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).


class Quadratic_Equation_Solver
{
    static void Main()
    {
        Console.WriteLine("Enter the first number \"a\":");
        double numberA = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number \"b\":");
        double numberB = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the third number \"c\":");
        double numberC = double.Parse(Console.ReadLine());

        //ax^2 + bx + c = 0

        double sqareRoot = (numberB * numberB) - (4 * numberA * numberC);
        double rootX1, rootX2, imgRoot, RootX;

        if (sqareRoot > 0)
        {
            rootX1 = (-numberB + Math.Sqrt(sqareRoot)) / (2 * numberA);
            rootX2 = (-numberB - Math.Sqrt(sqareRoot)) / (2 * numberA);
            Console.WriteLine("The Real Solution X1 = {0,8:F4}", rootX1);
            Console.WriteLine("The Real Solution X2 = {0,8:F4}", rootX2);
        }
        else if (sqareRoot < 0)
        {
            sqareRoot = -sqareRoot;
            RootX = -numberB / (2 * numberA);
            imgRoot = Math.Sqrt(sqareRoot) / (2 * numberA);
            Console.WriteLine("The Imaginary Solutions \nare  either: {0,8:f4} + {1,8:f4}i", RootX, imgRoot);
            Console.WriteLine("Or: {0,17:F4} + {1,8:F4}i", RootX, -imgRoot);
        }
        else
        {
            RootX = (-numberB + System.Math.Sqrt(sqareRoot)) / (2 * numberA);
            Console.WriteLine("One Real Solution: {0,8:F4}", RootX);
        }
    }
}
