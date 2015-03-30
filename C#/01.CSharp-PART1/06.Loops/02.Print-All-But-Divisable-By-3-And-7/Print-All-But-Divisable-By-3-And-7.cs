using System;

//Write a program that prints all the numbers from 1 to N, 
//that are not divisible by 3 and 7 at the same time.


class Print_All_But_Divisable_By_3_And_7
{
    static void Main()
    {
        Console.Write("Please enter a number N:");
        int numberN = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.Write("Numbers divisable By 3 and 7: ");
        for (int i = 0; i <= numberN; i++)
        {

            //if (i % 3 == 0 && i % 7 == 0) or
            if (i % 21 == 0)
            {
            Console.Write("{0}, ", i);
            }
        }
        Console.WriteLine();
    }
}