using System;

            //Write a program that reads 3 integer numbers from the console and prints their sum.


class Print_Sum_Of_3_Integer_Numbers
{
    static void Main()
    {
        Console.WriteLine("This is a program that reads 3 integer numbers- \nfrom the console and prints their sum.");
        Console.WriteLine("Enter the first number:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number:");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the third number:");
        int thirdNumber = int.Parse(Console.ReadLine());
        int result = firstNumber + secondNumber + thirdNumber;
        Console.WriteLine("The sum of {0}, {1}, {2} is equal to {3}.", firstNumber, secondNumber, thirdNumber, result);
    }
}
