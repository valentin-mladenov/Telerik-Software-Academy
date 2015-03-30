using System;
using System.Numerics;

//Write a program that calculates N!/K!
//for given N and K (1<K<N).

class Calculate_N_Fact_Slash_K_Fact
{
    static void Main()
    {
        Console.WriteLine("For given N and K (1<K<N):");
        Console.Write("Please enter a number N:");
        BigInteger numberN = BigInteger.Parse(Console.ReadLine());

        Console.Write("Please enter a number K:");
        BigInteger numberK = BigInteger.Parse(Console.ReadLine());

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        BigInteger resultNSlashK = 1;

        if (numberK > 1 && numberN > numberK)
        {
            for (int i = 1; i <= numberN; i++)
            {
                factorialN *= i;
                Console.Write(factorialN + " ");
            }
            Console.WriteLine();
            Console.WriteLine("N factorial: {0}.", factorialN);

            for (int j = 1; j <= numberK; j++)
            {

                factorialK *= j;
                Console.Write(factorialK + " ");
            }
            Console.WriteLine();
            Console.WriteLine("K factorial: {0}.", factorialK);

            resultNSlashK = factorialN / factorialK;
            Console.Write("N!/K! = {0}.", resultNSlashK);
        }

        else
        {
            Console.WriteLine("Error!!! Incorect numbers N and K. Please try again.");
            Main();
        }
        Console.WriteLine();
    }
}