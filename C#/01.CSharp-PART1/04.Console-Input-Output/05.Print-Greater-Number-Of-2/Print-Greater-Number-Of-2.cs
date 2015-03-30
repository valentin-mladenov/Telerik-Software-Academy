using System;

            //Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

class Print_Greater_Number_Of_2
{
    static void Main()
    {
        Console.WriteLine("Which number is greater:");
        Console.WriteLine("Please enter the first number:");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second number:");
        double secondNumber = double.Parse(Console.ReadLine());
        double maxNumber = Math.Max(firstNumber, secondNumber);
        Console.WriteLine("The Greater number is: {0}",maxNumber);

    }
}