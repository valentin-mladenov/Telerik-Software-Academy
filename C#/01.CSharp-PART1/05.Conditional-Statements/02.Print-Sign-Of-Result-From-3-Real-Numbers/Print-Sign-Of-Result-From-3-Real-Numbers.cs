using System;

//Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

class Print_Sign_Of_Result_From_3_Real_Numbers
{
    static void Main()
    {
        Console.WriteLine("Please enter the first number:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second number:");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the third number:");
        int thirdNumber = int.Parse(Console.ReadLine());

        if (firstNumber < 0 ^ secondNumber < 0 ^ thirdNumber < 0)
        {
            Console.WriteLine("The product of the numbers is negetive (-).");
        }

        else
        {
            Console.WriteLine("The product of the numbers is positive (+).");
        }
    }
}