using System;

//Write a program that finds the biggest of three integers using nested if statements.

class Find_Biggest_Of_Three
{
    static void Main()
    {
        Console.WriteLine("Please enter the first number:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second number:");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the third number:");
        int thirdNumber = int.Parse(Console.ReadLine());

        if (firstNumber > secondNumber)
        {
            if (secondNumber > thirdNumber)
            {
                Console.WriteLine("The first is biggest.");
            }
            else if (firstNumber > thirdNumber)
            {
                Console.WriteLine("The first is biggest.");
            }
        }

        if (secondNumber > firstNumber)
        {
            if (firstNumber > thirdNumber)
            {
                Console.WriteLine("The second is biggest.");
            }
            else if (secondNumber > thirdNumber)
            {
                Console.WriteLine("The second is biggest.");
            }
        }

        else
        {
            Console.WriteLine("The third is biggest.");
        }
    }
}