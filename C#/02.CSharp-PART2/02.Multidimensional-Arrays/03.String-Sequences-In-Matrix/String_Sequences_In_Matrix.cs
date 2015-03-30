using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//We are given a matrix of strings of size N x M.
//Sequences in the matrix we define as sets of
//several neighbor elements located on the same
//line, column or diagonal. Write a program that
//finds the longest sequence of equal strings in
//the matrix. Example:

//ha  fifi ho hi
//fo  ha  hi  xx --> ha,ha,ha
//xxx ho  ha  xx

//s  qq s
//pp pp s     --> s,s,s
//pp qq s


class String_Sequences_In_Matrix
{
    static void Main()
    {
        Console.Write("Number of rows = ");
        int rowCount = int.Parse(Console.ReadLine());
        Console.Write("Number of columns = ");
        int colCount = int.Parse(Console.ReadLine());

        string[,] matrix = new string[rowCount, colCount];

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }

        //string[,] matrix = new string[,] {
        //    {"ninja",       "ninja",        "izobilie",     "kusmet",       "uporitost"},
        //    {"priqtelstwo", "ninja",        "liubov",       "uporitost",    "kusmet"},
        //    {"smelost",     "sila",         "uporitost",        "kusmet",       "iskrenost"},
        //    {"uporitost",   "uporitost",    "spokoistvie",  "ninja",        "spokoistvie"},
        //        };
        //int rowCount = 4;
        //int colCount = 5;

        //Promenlivite za 4te varianta.
        int tempCount = 1;

        int maxCountRow = 0;
        int rowBestRow = 0;
        int rowBestCol= 0;

        int maxCountCol = 0;
        int colBestRow = 0;
        int colBestCol = 0;

        int maxCountUD = 0;
        int rowUpDown = 0;
        int colUpDown = 0;

        int maxCountDU = 0;
        int rowDownUp = 0;
        int colDownUp = 0;

        //Checked by row.
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount -1; j++)
            {
                if (matrix[i,j] == matrix[i,(j+1)])
                {
                    tempCount++;
                }

                if ((tempCount > maxCountRow) && (matrix[i, j] == matrix[i, (j + 1)]))
                {
                    maxCountRow = tempCount;
                    rowBestRow = i;
                    rowBestCol = j;
                }

                if (matrix[i,j] != matrix[i,(j+1)])
                {
                    tempCount = 1;

                }
            }
        }
        tempCount = 1;

        //Checked by column
        for (int i = 0; i < rowCount - 1; i++)
        {
            
            for (int j = 0; j < colCount; j++)
            {
                if (matrix[i, j] == matrix[(i+1), j])
                {
                    tempCount++;
                }

                if ((tempCount > maxCountCol) && (matrix[i, j] == matrix[(i + 1), j]))
                {
                    maxCountCol = tempCount;
                    colBestRow = i;
                    colBestCol = j;
                }
                if ((matrix[i, j] != matrix[(i + 1), j]))
                {
                    tempCount = 1;
                }
            }
        }
        tempCount = 1;

        //Check by diagonal up -> down.
        for (int i = 0; i < rowCount - 1; i++)
        {
            for (int j = 0; j < colCount - 1; j++)
            {
                for (int rows = i, cols = j; rows < rowCount - 1 && cols < colCount - 1; rows++, cols++)
                {

                    if (matrix[rows, cols] == matrix[(rows + 1), (cols + 1)])
                    {
                        tempCount++;
                    }

                    if ((tempCount > maxCountUD) && (matrix[rows, cols] == matrix[(rows + 1), (cols + 1)]))
                    {
                        maxCountUD = tempCount;
                        rowUpDown = rows;
                        colUpDown = cols;
                    }
                    if (matrix[rows, cols] != matrix[(rows + 1), (cols + 1)])
                    {
                        tempCount = 1;
                    }
                }
            }
        }
        tempCount = 1;

        //CHeck by diagonal down -> up.???
        for (int i = 0; i < rowCount - 1; i++)
        {
            for (int j = 1; j < colCount; j++)
            {
                for (int rows = i, cols = j; cols > 0 && rows < rowCount - 1; rows++, cols--)
                {

                    if (matrix[rows, cols] == matrix[(rows + 1), (cols - 1)])
                    {
                        tempCount++;
                    }

                    if ((tempCount > maxCountDU) && (matrix[rows, cols] == matrix[(rows + 1), (cols - 1)]))
                    {
                        maxCountDU = tempCount;
                        rowDownUp = rows;
                        colDownUp = cols;
                    }
                    if (matrix[rows, cols] != matrix[(rows + 1), (cols - 1)])
                    {
                        tempCount = 1;
                    }
                }
            }
        }

        //Check wich one is longer.
        int TempMax = 0;
        int bestRow = 0;
        int bestCol = 0;

        if (maxCountCol > TempMax)
        {
            TempMax = maxCountCol;
            bestCol = colBestCol;
            bestRow = colBestRow;
        }

        if (maxCountRow > TempMax)
        {
            TempMax = maxCountRow;
            bestRow = rowBestRow;
            bestCol = rowBestCol;
        }

        if (maxCountUD > TempMax)
        {
            TempMax = maxCountUD;
            bestRow = rowUpDown;
            bestCol = colUpDown;
        }

        if (maxCountDU > TempMax)
        {
            TempMax = maxCountDU;
            bestRow = rowDownUp;
            bestCol = colDownUp;
        }

        //Print Max Seq.
        Console.WriteLine("The longest sequence is with length: " + TempMax);
        Console.WriteLine("The value of the repeating string is: " + matrix[bestRow, bestCol]);

    }
}