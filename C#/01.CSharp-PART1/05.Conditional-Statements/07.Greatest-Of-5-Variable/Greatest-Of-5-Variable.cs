using System;

//Write a program that finds the greatest of given 5 variables.

    class Greatest_Of_5_Variable
{
    static void Main()
    {
        Console.WriteLine("Please enter the first number:");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second number:");
        double secondNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the third number:");
        double thirdNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the fourth number:");
        double fourthNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the fifth number:");
        double fifthNumber = double.Parse(Console.ReadLine());


        double greatestNumber = firstNumber;

        if (greatestNumber < secondNumber)
        {
            greatestNumber = secondNumber;
        }
        if (greatestNumber < thirdNumber)
        {
            greatestNumber = thirdNumber;
        }
        if (greatestNumber < fourthNumber)
        {
            greatestNumber = fourthNumber;
        }
        if (greatestNumber < fifthNumber)
        {
            greatestNumber = fifthNumber;
        }
        Console.WriteLine("The greatest number is {0}.", greatestNumber);
    }
}