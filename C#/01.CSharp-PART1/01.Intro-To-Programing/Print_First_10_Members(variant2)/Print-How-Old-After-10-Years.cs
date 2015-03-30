using System;

class Print_How_Old_After_10_Years
{
    static void Main()
    {
        int x;
        Console.WriteLine("What is your age:");
        x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("After 10 years you will be:");
        Console.WriteLine(x + 10);
    }
}
