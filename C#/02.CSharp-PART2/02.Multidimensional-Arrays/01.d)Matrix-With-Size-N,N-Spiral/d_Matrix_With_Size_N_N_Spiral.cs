using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that fills and
//prints a matrix of size (n, n)
//as shown below: (examples for n = 4)
//1 12 11 10
//2 13 16  9
//3 14 15  8
//4  5  6  7

class d_Matrix_With_Size_N_N_Spiral
{
    static void Main()
    {
        Console.Write("Enter number N:");
        int numbreN = int.Parse(Console.ReadLine());

        int[,] matrixN = new int[numbreN, numbreN];

        string direction = "down";
        int currentRow = 0;
        int currentCol= 0;

        for (int i = 1; i <= numbreN*numbreN; i++)
        {
            if (direction == "down" && (currentRow > (numbreN-1) || matrixN[currentRow,currentCol] != 0))
            {                
                currentCol++;
                currentRow--;
                direction = "right";
            }
            else if (direction == "right" && (currentCol > (numbreN - 1) || matrixN[currentRow, currentCol] != 0))
            {
                currentCol--;
                currentRow--;
                direction = "upward";
            }
            else if (direction == "upward" && (currentRow < 0 || matrixN[currentRow,currentCol] != 0))
            {
                currentCol--;
                currentRow++;
                direction = "left";
            }
            else if (direction == "left" && (currentCol < 0 || matrixN[currentRow,currentCol] != 0))
            {
                direction = "down";
                currentRow++;
                currentCol++;
            }

            matrixN[currentRow, currentCol] = i;

            if (direction == "down")
	        {
		        currentRow++;
	        }
            else if (direction == "right")
            {
                currentCol++;
            }
            else if (direction == "upward")
            {
                currentRow--;
            }
            else if(direction == "left")
            {
                currentCol--;
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