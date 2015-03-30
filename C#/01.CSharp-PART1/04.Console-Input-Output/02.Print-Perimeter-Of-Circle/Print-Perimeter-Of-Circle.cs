using System;

            //Write a program that reads the radius r of a circle and prints it's perimeter and area.


class Print_Perimeter_Of_Circle
{
    static void Main()
    {
        Console.WriteLine("This is a program that reads the radius R \nof a circle and prints it's perimeter and area.");
        Console.WriteLine("Enter the radius R:");
        double radiusR = double.Parse(Console.ReadLine());
        double pi = 3.14;
        double circlePerimeter = 2 * pi * radiusR;
        double circleArea = pi * radiusR * radiusR;
        Console.WriteLine("The perimeter of a circle with radius R = {0} is: {1}.", radiusR,circlePerimeter);
        Console.WriteLine("The area of a circle with radius R = {0} is: {1}.", radiusR, circleArea);
    }
}