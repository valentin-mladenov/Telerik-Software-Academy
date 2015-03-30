using System;

        //Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).


class Point_Within_Circle_K_And_Retangle_R
{
    static void Main()
    {
        Console.WriteLine("Enter X.");
        double x = double.Parse(Console.ReadLine());
        double circleX = x - 1;
        Console.WriteLine("Enter Y.");
        double y = double.Parse(Console.ReadLine());
        double circleY = y - 1;
        double circleR = 3;
        {
            if ((circleX * circleX) + (circleY * circleY) <= (circleR * circleR))
                Console.WriteLine("The point is within the Circle K.");
            else
                Console.WriteLine("The point is out the Circle K.");
        }
        double retangleX = x - 1;
        double retangleY = y + 3;
        double heigth = 2;
        double width = 6;
        {
            if ((retangleX >= 0 && retangleX <= width) && (retangleY >= 0 && retangleY <= heigth))
                Console.WriteLine("The point is within the Retangle R.");
            else
                Console.WriteLine("The point is out the Retangle R.");
        }
    }
}