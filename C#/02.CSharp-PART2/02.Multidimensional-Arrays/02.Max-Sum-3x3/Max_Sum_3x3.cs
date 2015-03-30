using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a rectangular
//matrix of size N x M and finds in it the
//square 3 x 3 that has maximal sum of its elements.


class Max_Sum_3x3
{
    static void Main()
    {
        Console.Write("Number of rows = ");
        int rowCount = int.Parse(Console.ReadLine());
        Console.Write("Number of columns = ");
        int colCount = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rowCount, colCount];

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        //Marix with spaces, TABs or "-" between numbers.
        //string[] separators = new string[] { " ", "\t", "-" };
        //for (int row = 0; row < rowCount; row++)
        //{
        //    string currentRow = Console.ReadLine();
        //    string[] numbers = currentRow.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        //    for (int col = 0; col < numbers.Length; col++)
        //    {
        //        if (col < colCount)
        //        {
        //            matrix[row, col] = int.Parse(numbers[col]);
        //        }
        //    }
        //}

        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        Console.WriteLine("The best platform is:");
        Console.WriteLine("  {0} {1} {2}", 
            matrix[bestRow, bestCol], 
            matrix[bestRow, bestCol + 1], 
            matrix[bestRow, bestCol + 2]);
        Console.WriteLine("  {0} {1} {2}", 
            matrix[bestRow + 1, bestCol], 
            matrix[bestRow + 1, bestCol + 1], 
            matrix[bestRow + 1, bestCol + 2]);
        Console.WriteLine("  {0} {1} {2}", 
            matrix[bestRow + 2, bestCol], 
            matrix[bestRow + 2, bestCol + 1], 
            matrix[bestRow + 2, bestCol + 2]);
        Console.WriteLine("The maximal sum is: {0}", bestSum);
    }
}