using System;

            //Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.


class Positive_Prime_Number
{
    static void Main()
    {
        Console.WriteLine("Enter a positive number ≤ 100:");
        int primeOrNot = int.Parse(Console.ReadLine());
        if (primeOrNot <= 100)
        {
            if ((primeOrNot % 2 == 0 || primeOrNot % 3 == 0 || primeOrNot % 5 == 0 || primeOrNot % 7 == 0) && (primeOrNot != 1 && primeOrNot != 2 && primeOrNot != 3 && primeOrNot != 5 && primeOrNot != 7))
                Console.WriteLine("The number is composite.");
            else
                Console.WriteLine("The number is prime.");
        }
        else Console.WriteLine("The number is > 100.");
    }
}
