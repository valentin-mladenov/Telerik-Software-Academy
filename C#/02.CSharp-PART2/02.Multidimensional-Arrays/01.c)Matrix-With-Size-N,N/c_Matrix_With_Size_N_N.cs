using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that fills and
//prints a matrix of size (n, n)
//as shown below: (examples for n = 4)
//7 11 14 16
//4  8 12 15
//2  5  9 13
//1  3  6 10

class c_Matrix_With_Size_N_N
{
    static void Main()
    {
        Console.Write("Enter number N:");
        int numbreN = int.Parse(Console.ReadLine());

        int[,] matrixN = new int[numbreN, numbreN];

        int row = numbreN - 1;
        int col = 0;
        int startRow = numbreN - 1;
        int startCol = 0;
        int digit = 1;

        matrixN[row, col] = 1;

        while (digit < (numbreN * numbreN))
        {
            if (row == (numbreN - 1) && col < (numbreN - 1))
            {
                startRow--;
                startCol = 0;
                row = startRow;
                col = startCol;
                digit++;
                matrixN[row, col] = digit;

                while (row < (numbreN - 1) && col < (numbreN - 1))
                {
                    row++;
                    col++;
                    digit++;
                    matrixN[row, col] = digit;
                }
            }

            if (row <= (numbreN - 1) && col == (numbreN - 1))
            {
                startRow = 0;
                startCol++;
                row = startRow;
                col = startCol;
                digit++;
                matrixN[row, col] = digit;

                while (col < (numbreN - 1))
                {
                    row++;
                    col++;
                    digit++;
                    matrixN[row, col] = digit;
                }
            }
        }

        Console.WriteLine("The matrix is as follows:");
        for (int i = 0; i < numbreN; i++)
        {
            for (int j = 0; j < numbreN; j++)
            {
                Console.Write("{0} ", matrixN[i, j]);
            }
            Console.WriteLine();
        }
    }
}