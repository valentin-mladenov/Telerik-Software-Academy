using System;
using System.Numerics;

// *  Write a program that calculates for given N how many
//    trailing zeros present at the end of the number N!. Examples:
//    N = 10  N! = 3628800  2
//    N = 20  N! = 2432902008176640000  4
//    Does your program work for N = 50 000?
//    Hint: The trailing zeros in N! are equal to the number
//    of its prime divisors of value 5. Think why!


class Trailing_Zeros_Present_In_Number_N
{
    static void Main()
    {
        Console.WriteLine("Calculate how many trailing zeros present at the end of the number N!.");
        Console.Write("Please enter a  number N:");
        BigInteger numberN = BigInteger.Parse(Console.ReadLine());

        int resultTrailingZeros = 0;
        BigInteger factorialN = 1;

        for (BigInteger i = 1; i <= numberN; i++)
        {
            factorialN *= i;
            //Console.Write(factorialN + " ");
        }

        Console.WriteLine();
        Console.WriteLine("N factorial: {0}.", factorialN);

        for (int i = 1; i <= numberN; i++)
        {
            int middleNumberN = i;

            while (middleNumberN % 5 == 0)
            {
                resultTrailingZeros ++;
                middleNumberN /= 5;
            } 
        }
        Console.WriteLine("Trailing zeros: {0}", resultTrailingZeros);
    }
}