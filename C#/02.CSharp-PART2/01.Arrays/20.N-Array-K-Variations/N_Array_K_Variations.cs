using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads two numbers
//N and K and generates all the variations
//of K elements from the set [1..N]. Example:
//N = 3, K = 2  {1, 1}, {1, 2}, {1, 3},
//{2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}


class N_Array_K_Variations
{
    static void Main()
    {
        Console.WriteLine("Enter Number N and Number K.");

        int numberN = int.Parse(Console.ReadLine());
        int numberK = int.Parse(Console.ReadLine());

        if (numberK > numberN)
        {
            Console.WriteLine("Error: Number K must be smaller than Number N. Enter new numbers:");
            Main();
        }

        else
        {

            int[] arrayK = new int[numberK];

            Variations(arrayK, 0, numberN);
        }
    }

    private static void Variations(int[] arrayK, int numberK, int numberN)
    {
        if (numberK == arrayK.Length)
        {
            PrintResult(arrayK);
        }
        else
        {
            for (int i = 1; i <= numberN; i++)
            {
                arrayK[numberK] = i;
                Variations(arrayK, numberK + 1, numberN);
            }
        }
    }

    private static void PrintResult(int[] arrayK)
    {
        foreach (var number in arrayK)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}