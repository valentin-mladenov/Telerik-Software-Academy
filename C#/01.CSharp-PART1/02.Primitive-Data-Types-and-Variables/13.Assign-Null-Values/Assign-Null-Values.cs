using System;

class Assign_Null_Values
{
    static void Main()
    {
        int? anyInteger = null;
        Console.WriteLine("This is the integer with Null value -> " + anyInteger);
        anyInteger = 25;
        Console.WriteLine("This is the integer with value 25 -> " + anyInteger);

        double? anyDouble = null;
        Console.WriteLine("This is the real number with Null value -> " + anyDouble);
        anyDouble = 32.5;
        Console.WriteLine("This is the real number with value 32,5 -> " + anyDouble);
    }
}