using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write methods that calculate the
//surface of a triangle by given:
//Side and an altitude to it; Three sides;
//Two sides and an angle between them. Use System.Math.

class Triangle_Surface
{
    static double SideAndAltitude(double side, double altitude)
    {
        double surface = (side * altitude) / 2;
        double end = Math.Round(surface, 4);

        return end;
    }

    static double ThreeSides(double sideA, double sideB, double sideC)
    {
        double halfPerimeter = (sideA + sideB + sideC) /2;
        double sqrt = halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC);
        double surface = Math.Sqrt(sqrt);
        double end = Math.Round(surface, 4);

        return end;
    }

    static double TwoSidesAndAngle(double sideA, double sideB, double angle)
    {
        double radians = angle * (Math.PI / 180);
        double surface = (sideA * sideB * Math.Sin(radians)) / 2;
        double end = Math.Round(surface, 4);

        return end;
    }

    static void Main()
    {
        Console.WriteLine("Which method for calculation of the surface of a triangle:");
        Console.WriteLine("For method: Side and an altitude to it press (1).");
        Console.WriteLine("For method: Three sides press (2).");
        Console.WriteLine("For method: Two sides and an angle between them (3).");

        char method = char.Parse(Console.ReadLine());

        if (method == '1')
        {
            Console.Write("Enter value of the side: ");
            double side = double.Parse(Console.ReadLine());
            Console.Write("Enter value of the altitude: ");
            double altitude = double.Parse(Console.ReadLine());

            Console.WriteLine(SideAndAltitude(side, altitude));
        }
        else if (method == '2')
        {
            Console.Write("Enter value for side A: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Enter value for side B: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Enter value for side C: ");
            double sideC = double.Parse(Console.ReadLine());

            Console.WriteLine(ThreeSides(sideA, sideB, sideC));
        }
        else if (method == '3')
        {
            Console.Write("Enter value for side A: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.Write("Enter value for side B: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.Write("Enter value for the angle in degrees: ");
            double angle = double.Parse(Console.ReadLine());

            Console.WriteLine(TwoSidesAndAngle(sideA, sideB, angle));
            
        }
        else
        {
            Console.WriteLine("ERROR!!! Incorect method.");
            Console.WriteLine();
            Main();

        }
    }
}