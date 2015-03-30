// Write a recursive program to find the largest
// connected area of adjacent empty cells in a matrix.

namespace _09.Adjancet_Empty_Cells
{
    using System;
    using System.Collections.Generic;

    internal class AdjancetEmptyCells
    {
        public static int[,] labytinth =
            {
                { 0, 0, 0, -1, 0, 0, 0 },
                { -1, -1, 0, -1, 0, -1, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, -1, -1, -1, -1, -1, 0 },
                { 0, 0, 0, 0, 0, 0, 0 }
            };

        public static List<int> counts = new List<int>();
        public static int count = 0;

        public static void FindPaths(int row, int col)
        {
            if (col < 0 || row < 0 || col >= labytinth.GetLength(1) || row >= labytinth.GetLength(0))
            {
                return;
            }

            if (labytinth[row, col] > 0)
            {
                counts.Add(labytinth[row, col]);
                return;
            }

            if (labytinth[row, col] != 0)
            {
                return;
            }

            count++;

            labytinth[row, col] = count;

            FindPaths(row, col + 1); // rigth
            FindPaths(row + 1, col); // down
            FindPaths(row, col - 1); // left
            FindPaths(row - 1, col); // up

            labytinth[row, col] = 0;
            count--;
        }



        static void Main()
        {
            FindPaths(0, 0);
            counts.Sort();
            Console.WriteLine(counts[counts.Count-1].ToString());
        }
    }
}