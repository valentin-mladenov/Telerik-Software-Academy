using System;

//Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.


class Exchanges_Values
{
    static void Main()
    {
        Console.WriteLine("Please enter the first number:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second number:");
        int secondNumber = int.Parse(Console.ReadLine());
        int temporal;

        if (firstNumber > secondNumber)
        {
            temporal = secondNumber;
            secondNumber = firstNumber;
            firstNumber = temporal;
            Console.WriteLine("The first number is greater. Lets exchange them. \nNow The First is {0} and the second is {1}." , firstNumber,secondNumber);

        }
        else if (firstNumber < secondNumber)
        {
            Console.WriteLine("The second number is greater. No changes are needed.");
        }
        else
        {
            Console.WriteLine("The numbers are even.");
        }
    }
}