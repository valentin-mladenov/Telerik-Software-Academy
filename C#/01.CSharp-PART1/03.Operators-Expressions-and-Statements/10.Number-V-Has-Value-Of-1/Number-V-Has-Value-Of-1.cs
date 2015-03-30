using System;

        //Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.

class Number_V_Has_Value_Of_1
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a bit position:");
        int position = int.Parse(Console.ReadLine());
        int mask = number >> position;
        int numberV = mask & 1;
        bool checkNumber = (numberV == 1);
        if (checkNumber)
            Console.WriteLine("The bit position {1} of number {0} have value of 1: {2}.", number, position, checkNumber);
        else
            Console.WriteLine("The bit position {1} of number {0} have value of 1: {2}", number, position, checkNumber);
    }
}