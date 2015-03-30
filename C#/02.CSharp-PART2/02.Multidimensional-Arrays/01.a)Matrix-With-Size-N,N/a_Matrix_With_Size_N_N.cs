using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that fills and
//prints a matrix of size (n, n)
//as shown below: (examples for n = 4)
//1 5  9 13
//2 6 10 14
//3 7 11 15
//4 8 12 16

class a_Matrix_With_Size_N_N
{
    static void Main(string[] args)
    {
        Console.Write("Enter number N:");
        int numbreN = int.Parse(Console.ReadLine());

        int row = numbreN;
        int col = numbreN;
        int temp = 0;

        int[,] matrixN = new int[row, col];

        for (int i = 0; i < col; i++)
        {
            int index = 1 + temp; 
            for (int j = 0; j < row; j++)
            {
                matrixN[j,i] = index;
                temp = index;
                index ++;
            }
        }
        Console.WriteLine("The matrix is as follows:");
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.Write("{0} ", matrixN[i, j]);
            }
            Console.WriteLine();
        }
    }
}