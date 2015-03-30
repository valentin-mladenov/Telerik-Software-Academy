using System;

class Compares_Floating_Point_Numbers
{
    static void Main()
    {
        float a = 2.254F;
        float b = 3.012F;
        Boolean Compare = (a == b);
        Console.WriteLine("Compare is: {0}", Compare);

        float x = 111.12345678F;
        float y = 111.12345679F;
        Boolean Compare2 = (x == y);
        Console.WriteLine("Compare2 is: {0}", Compare2);

    }
}