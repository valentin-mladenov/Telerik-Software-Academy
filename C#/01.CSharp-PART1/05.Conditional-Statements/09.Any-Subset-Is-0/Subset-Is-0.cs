using System;

//We are given 5 integer numbers. Write a program that checks if the
//sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.

class Any_Subset_Is_0
{
    static void Main()
    {
        Console.WriteLine("Please enter the first number:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second number:");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the third number:");
        int thirdNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the fourth number:");
        int fourthNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the fifth number:");
        int fifthNumber = int.Parse(Console.ReadLine());

        // Five numbers

        if (firstNumber + secondNumber + thirdNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of all numbers is Zero.");
        }

        // Four numbers.

        if (firstNumber + secondNumber + thirdNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of first, second, third and fourth numbers is Zero.");
        }

        if (firstNumber + secondNumber + thirdNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of first, second, third and fifth numbers is Zero.");
        }

        if (firstNumber + secondNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of first, second, fourth and fifth numbers is Zero.");
        }

        if (firstNumber + thirdNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of first, third, fourth and fifth numbers is Zero.");
        }

        if (secondNumber + thirdNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of second, third, fourth and fifth numbers is Zero.");
        }

        //Three numbers.

        if (firstNumber + secondNumber + thirdNumber == 0)
        {
            Console.WriteLine("The sum of first, second and third numbers is Zero.");
        }

        if (firstNumber + secondNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of first, second and fourth numbers is Zero.");
        }

        if (firstNumber + secondNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of first, second and fifth numbers is Zero.");
        }

        if (firstNumber + thirdNumber + fifthNumber== 0)
        {
            Console.WriteLine("The sum of first, third and fifth numbers is Zero.");
        }

        if (firstNumber + thirdNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of first, third and fourth numbers is Zero.");
        }

        if (firstNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of first, fourth and fifth numbers is Zero.");
        }

        if (secondNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of second, fourth and fifth numbers is Zero.");
        }

        if (secondNumber + thirdNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of second, third and fifth numbers is Zero.");
        }

        if (secondNumber + thirdNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of second, third and fourth numbers is Zero.");
        }

        if (thirdNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of second, fourth and fifth numbers is Zero.");
        }

        //Two numbers.

        if (firstNumber + secondNumber == 0)
        {
            Console.WriteLine("The sum of first and second numbers is Zero.");
        }

        if (firstNumber + thirdNumber == 0)
        {
            Console.WriteLine("The sum of first and third numbers is Zero.");
        }

        if (firstNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of first and fourth numbers is Zero.");
        }

        if (firstNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of first and fifth numbers is Zero.");
        }

        if (secondNumber + thirdNumber == 0)
        {
            Console.WriteLine("The sum of second and third numbers is Zero.");
        }

        if (secondNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of second and fourth numbers is Zero.");
        }

        if (secondNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of second and fifth numbers is Zero.");
        }

        if (thirdNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of third and fourth numbers is Zero.");
        }

        if (thirdNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of third and fifth numbers is Zero.");
        }

        if (fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of fourth and fifth numbers is Zero.");
        }

        else
        {
            Console.WriteLine("No subsum is Zero.");
        }
     }
}