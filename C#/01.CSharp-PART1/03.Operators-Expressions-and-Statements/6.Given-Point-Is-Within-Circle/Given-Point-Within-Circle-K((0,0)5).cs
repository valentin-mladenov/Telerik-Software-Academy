using System;

            Write an expression that checks if given point (x,  y) is within a circle K(O, 5).


class Given_Point_Within_Circle
{
    static void Main()
    {
        Console.WriteLine("Enter X.");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Y.");
        double y = double.Parse(Console.ReadLine());
        double r = 5;
        if (x*x + y*y <= r*r)
            Console.WriteLine("The point is within the circle K(0,5).");
        else
            Console.WriteLine("The point is out the circle K(0,5).");
    }
}