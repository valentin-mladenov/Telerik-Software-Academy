using System;
using System.Linq;

//Define abstract class Shape with only one abstract method CalculateSurface()
//and fields width and height. Define two new classes Triangle and Rectangle 
//that implement the virtual method and return the surface of the figure
//(height*width for rectangle and height*width/2 for triangle).
//Define class Circle and suitable constructor so that at initialization height
//must be kept equal to width and implement the CalculateSurface() method. 
//Write a program that tests the behavior of  the CalculateSurface()
//method for different shapes (Circle, Rectangle, Triangle) stored in an array.

namespace _01.Shapes
{
    class ShapesMain
    {
        static void Main()
        {
            Shape[] shapes = new Shape[]
            {
                new Triangle(2.3, 5.6),
                new Rectangle(4.6, 6.2),
                new Circle(6.3)
            };

            foreach (var item in shapes)
            {
                Console.Write(item.GetType().Name + " with surface: ");
                Console.WriteLine(Math.Round(item.CalculateSurface(), 2));
            }
        }
    }
}