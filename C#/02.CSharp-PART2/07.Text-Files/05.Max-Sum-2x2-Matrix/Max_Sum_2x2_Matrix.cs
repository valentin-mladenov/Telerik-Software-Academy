using System;
using System.IO;

//Write a program that reads
//a text file containing a square
//matrix of numbers and finds in
//the matrix an area of size 2 x 2
//with a maximal sum of its elements.
//The first line in the input file
//contains the size of matrix N.
//Each of the next N lines contain N
//numbers separated by space. The
//output should be a single number
//in a separate text file. Example:
//4
// 2 3  3 4
// 0 2  3 4			
//(3 7) 1 2  ---> 17
//(4 3) 3 2


class Max_Sum_2x2_Matrix
{
    static void Main()
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);
        string textfile = @"..\..\matrix.txt";
        StreamReader streamRdr = new StreamReader(textfile, encoding);

        int firstLine = int.Parse(streamRdr.ReadLine());
        string[] rows = new string[firstLine];        
        int[,] matrix = new int[firstLine, firstLine];
        string[] separators = new string[] { " ", "\t", "-" };

        using (streamRdr)
        {
            int lineNum = -1;
            string line = streamRdr.ReadLine();

            while (line != null)
            {
                lineNum++;                
                rows[lineNum] = line;
                line = streamRdr.ReadLine();
            }
        }

        for (int i = 0; i < rows.Length; i++)
        {
            string[] numbers = rows[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < numbers.Length; j++)
            {
                if (j < rows.Length)
                {
                    matrix[i, j] = int.Parse(numbers[j]);
                }
            }
        }

        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }
        string maxSum = @"..\..\bestSum.txt";
        StreamWriter strWrt = new StreamWriter(maxSum, false, encoding);

        strWrt.WriteLine("{0} {1}", matrix[bestRow, bestCol], matrix[bestRow, bestCol + 1]);
        strWrt.WriteLine("{0} {1}", matrix[bestRow + 1, bestCol], matrix[bestRow + 1, bestCol + 1]);       
        strWrt.WriteLine("The maximal sum is: {0}", bestSum);
        strWrt.Close();

        Console.WriteLine("File is written!");
    }
}