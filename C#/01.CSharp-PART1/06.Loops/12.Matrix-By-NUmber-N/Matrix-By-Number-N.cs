using System;

//Write a program that reads from the console
//a positive integer number N (N < 20) and
//outputs a matrix like the following:
//    N = 3			N = 4

class Matrix_By_NUmber_N
{
    static void Main()
    {
        Console.WriteLine("Calculate and output matrix by given number N.");
        Console.Write("Please enter a  number N (N < 20):");
        int numberN = int.Parse(Console.ReadLine());

        for (int row = 1; row <= numberN; row++)
        {
            int numverNPlusRow = numberN + row;

            for (int column = row; column < numverNPlusRow; column++)
            {                
                Console.Write("{0} ", column);
            }
            Console.WriteLine();
        }
    }
}