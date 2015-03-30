using System;

        //Write an expression that checks if given integer is odd or even.


class Integer_Is_Odd_Or_Even
{
    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int oddOrIven = int.Parse(Console.ReadLine());
        if (oddOrIven % 2 == 0)
            Console.WriteLine("The number is even.");
        else
            Console.WriteLine("The number is odd.");
    }
}