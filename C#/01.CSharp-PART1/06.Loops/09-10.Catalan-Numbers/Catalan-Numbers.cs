using System;
using System.Numerics;

//In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:
//Cn = ((2 * n)!) / (((n + 1)!) * n!)
//Write a program to calculate the Nth Catalan number by given N.


class Catalan_Numbers
{
    static void Main()
    {
        Console.WriteLine("Calculate the Nth Catalan number by given N.");
        Console.Write("Please enter a Catalan N for (N >=0):");
        BigInteger catalanN = BigInteger.Parse(Console.ReadLine());

        BigInteger CatalanNM2 = (catalanN * 2);
        BigInteger factorialCatalanNM2 = 1;
        BigInteger CatalanNPlus1 = (catalanN + 1);
        BigInteger factorialCatalanNPlus1 = 1;
        BigInteger factorialCatalanN = 1;
        BigInteger catalanSumN;

        if (catalanN >= 0)
        {
            for (int i = 1; i <= catalanN; i++)
            {
                factorialCatalanN *= i;
            }

            for (int j = 1; j <= CatalanNM2; j++)
			{
			    factorialCatalanNM2 *= j;
			}

            for (int k = 1; k <= CatalanNPlus1; k++)
			{
			    factorialCatalanNPlus1 *= k;
			}
            catalanSumN = factorialCatalanNM2 / (factorialCatalanNPlus1 * factorialCatalanN);

            Console.WriteLine("Nth Catalan number is: {0}", catalanSumN);
        }

        else
        {
            Console.WriteLine("Error!!! Incorect Catalan N. Please try again.");
            Console.WriteLine();
            Main();
        }
    }
}
