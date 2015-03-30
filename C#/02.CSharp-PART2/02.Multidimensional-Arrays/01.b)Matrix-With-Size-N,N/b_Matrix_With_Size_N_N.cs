using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that fills and
//prints a matrix of size (n, n)
//as shown below: (examples for n = 4)
//1 8  9 16
//2 7 10 15
//3 6 11 14
//4 5 12 13

class b_Matrix_With_Size_N_N
{
    static void Main(string[] args)
    {
        Console.Write("Enter number N:");
        int numbreN = int.Parse(Console.ReadLine());

        int row = numbreN;
        int col = numbreN;
        int temp = 0;

        int[,] matrixN = new int[row, col];

        for (int i = 0; i < row; i++)
        {
            int index = 1 + temp;

            if (i % 2 == 0)
            {

                for (int j = 0; j < col; j++)
                {
                    matrixN[j, i] = index;
                    temp = index;
                    index++;
                }
            }
            else
            {
                index = index + numbreN - 1;
                int temp1 = temp;
                for (int j = 0; j < col; j++)
                {
                    matrixN[j, i] = index;
                    temp = index;
                    index--;
                }
                temp = temp1 + numbreN;
                //temp = (2  * numbreN) - (numbreN * (i-1));
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