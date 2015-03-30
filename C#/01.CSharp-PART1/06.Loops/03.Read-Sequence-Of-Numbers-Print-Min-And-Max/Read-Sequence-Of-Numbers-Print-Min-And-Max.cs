using System;

//Write a program that reads from the console a sequence of N
//integer numbers and returns the minimal and maximal of them.


class Read_Sequence_Of_Numbers_Print_Min_And_Max
{
    static void Main()
    {
        Console.WriteLine("How many numbers you will enter?");
        int counterN = int.Parse(Console.ReadLine());

        int minN = 0;
        int maxN = 0;

        for (int i = 1; i <= counterN; i++)
        {
            Console.WriteLine("Please enter a number:");
            int numberN = int.Parse(Console.ReadLine());

            if (i == 1)
            {
                minN = numberN;
                maxN = numberN;
            }

            if (numberN < minN)
            {
                minN = numberN;
            }

            if (numberN > maxN)
            {
                maxN = numberN;
            }
        }
        Console.WriteLine("The minimum number is: {0}", minN);
        Console.WriteLine("The maximum number is: {0}", maxN);
    }
}