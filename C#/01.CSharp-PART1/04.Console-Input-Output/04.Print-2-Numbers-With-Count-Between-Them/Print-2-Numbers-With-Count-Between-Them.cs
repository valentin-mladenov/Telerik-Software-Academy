using System;

                //Write a program that reads two positive integer numbers and prints how many numbers  The number of the digits in the range ..... , which could be divided by
                //p exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.


class Print_2_Numbers_With_Count_Between_Them
{
    static void Main()
    {
        Console.WriteLine("Enter the first positive integer:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second positive integer:");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the positive counter is:");
        int numberP = int.Parse(Console.ReadLine());

        int minNum = Math.Min(firstNumber, secondNumber);
        int maxNum = Math.Max(firstNumber, secondNumber);
        
        int counter;

        if ((firstNumber % numberP == 0) || (secondNumber % numberP == 0))
        {
            counter = (int)((Math.Abs(firstNumber - secondNumber) - 1) / numberP) + ((firstNumber % numberP) == 0 ? 1 : 0) + ((secondNumber % numberP) == 0 ? 1 : 0);
            Console.WriteLine("The number of the digits in the range ({0} - {1}),\nwhich could be divided by {2} are {3}.", minNum, maxNum, numberP, counter);
        }
        else
        {
            counter = (int)(((Math.Abs(firstNumber - secondNumber) - 1) / numberP) + ((minNum % numberP) + numberP - ((maxNum % numberP) / numberP))/numberP);
            Console.WriteLine("The number of the digits in the range ({0} - {1}),\nwhich could be divided by {2} are {3}.", minNum, maxNum, numberP, counter);
        }
    }
}