using System;

//Write a program that enters the coefficients a, b and c of a quadratic equation
//a*x2 + b*x + c = 0
//and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.


class Quadratic_Equation_Real_Roots
{
    static void Main()
    {
        Console.WriteLine("Let's find the real roots of quadratic equation a*x^2 + b*x + c = 0.");
        Console.WriteLine("Please enter coefficient \"a\":");
        int coefficientA = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter coefficient \"b\"");
        int coefficientB = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the coefficient \"c\"");
        int coefficientC = int.Parse(Console.ReadLine());

        double sqareRoot = (coefficientB * coefficientB) - (4 * coefficientA * coefficientC);
        double rootX1, rootX2, imgRoot, RootX;

        if (sqareRoot > 0)
        {
            rootX1 = (-coefficientB + Math.Sqrt(sqareRoot)) / (2 * coefficientA);
            rootX2 = (-coefficientB - Math.Sqrt(sqareRoot)) / (2 * coefficientA);
            Console.WriteLine("The real root X1 = {0,8:F4}", rootX1);
            Console.WriteLine("The real root X2 = {0,8:F4}", rootX2);
        }

        else if (sqareRoot < 0)
        {
            Console.WriteLine("No real roots.");
        }

        else
        {
            RootX = (-coefficientB + System.Math.Sqrt(sqareRoot)) / (2 * coefficientA);
            Console.WriteLine("One real root: {0,8:F4}", RootX);
        }
    }
}