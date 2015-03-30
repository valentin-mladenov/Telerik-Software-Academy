using System;

//Sort 3 real values in descending order using nested if statements.

class Sort_3_Descending_Order
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
                Console.WriteLine("The first ({0}) is the greates, then is the second ({1}) and the third ({2}) is last.", firstNumber, secondNumber, thirdNumber);
            }
            else if (secondNumber < thirdNumber)
            {
                Console.WriteLine("The first ({0}) is the greates, then is the third ({2}) and the second ({1}) is last.", firstNumber, secondNumber, thirdNumber);
            }
        }

        if (secondNumber > thirdNumber)
        {
            if (firstNumber > thirdNumber)
            {
                Console.WriteLine("The second ({1}) is the greates, then is the first ({0}) and the third ({2}) is last.", firstNumber, secondNumber, thirdNumber);
            }
            else if (firstNumber < thirdNumber)
            {
                Console.WriteLine("The second ({1}) is the greates, then is the third ({2}) and the first ({0}) is last.", firstNumber, secondNumber, thirdNumber);
            }
        }

        if (thirdNumber > firstNumber)
        {
            if (secondNumber > firstNumber)
            {
                Console.WriteLine("The third ({2}) is the greates, then is the second ({1}) and the first ({0}) is last.", firstNumber, secondNumber, thirdNumber);
            }
            else if (secondNumber < firstNumber)
            {
                Console.WriteLine("The third ({2}) is the greates, then is the first ({0}) and the second ({1}) is last.", firstNumber, secondNumber, thirdNumber);
            }
        }
    }
}