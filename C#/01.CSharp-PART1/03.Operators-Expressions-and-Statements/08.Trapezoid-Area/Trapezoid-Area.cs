using System;

            //Write an expression that calculates trapezoid's area by given sides a and b and height h.


class Trapezoid_Area
{
    static void Main()
    {
        Console.WriteLine("Enter side \"a\".");
            double sideA = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter side \"b\".");
            double sideB = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter height.");
            double height = double.Parse(Console.ReadLine());
            double area = (((sideA + sideB)/2)*height);
            Console.WriteLine("Trapezoid Area:" + area);
    }
}