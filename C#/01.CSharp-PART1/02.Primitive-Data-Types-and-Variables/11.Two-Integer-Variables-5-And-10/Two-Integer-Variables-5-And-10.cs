using System;

class Two_Integer_Variables_5_And_10
{
    static void Main()
    {
        Console.WriteLine("True values:");
        int a = 5;
        int b = 10;
        int c;
        Console.WriteLine("a=" + a);
        Console.WriteLine("b=" + b);
        c = a + b;
        b = c - b;
        a = c - a;
        Console.WriteLine("Chenged values:");
        Console.WriteLine("a=" + a);
        Console.WriteLine("b=" + b);
    }
}