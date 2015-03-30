using System;

//Write a program that prints all the numbers from 1 to N.

class Print_All_From_1_To_N
{
    static void Main()
    {
        Console.Write("Please enter a counter N:");
        int counterN = int.Parse(Console.ReadLine());

        int numberNMax = 0;
        int numberNMin = 0;

        for (int i = 1; i <= counterN; i++)
        {
            Console.Write("Please enter a number.");
            int numberN = int.Parse(Console.ReadLine());
                          
            if (i == 1)
            {
                numberNMax = numberN;
                numberNMin = numberN;
            }

            if (numberN < numberNMin)
            {
                numberNMin = numberN;
            }

            if (numberN > numberNMax)
            {
                numberNMax = numberN;
            }
        }
            Console.WriteLine("Max {0}. \nMin {1}.", numberNMax, numberNMin);
    }
}