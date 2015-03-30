using System;

//Write a program that reads a number
//and prints it as a decimal number,
//hexadecimal number, percentage and
//in scientific notation. Format the
//output aligned right in 15 symbols.


class Number_And_Its_Representation
{
    static void Main()
    {
        double number = double.Parse(Console.ReadLine());

        Console.WriteLine("{0,15:D}", (int)Math.Round(number, 0));
        Console.WriteLine("{0,15:X}", (int)Math.Round(number, 0));
        Console.WriteLine("{0,15:P}", number);
        Console.WriteLine("{0,15:E}", number);
    }
}