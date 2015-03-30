using System;

                    //Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.


class Integer_Divided_By_5_And_7
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int divided5or7 = int.Parse(Console.ReadLine());
            if (divided5or7 % 5 == 0 && divided5or7 % 7 == 0)
        Console.WriteLine("Divided by 5 and 7: True");
            else
        Console.WriteLine("Divided by 5 and 7: False");
    }
}