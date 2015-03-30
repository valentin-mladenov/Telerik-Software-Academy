// *
// We are given a matrix of passable and non-passable cells.
// Write a recursive program for finding all areas of passable cells in the matrix.

namespace _10.Find_All_Passable_Cells
{
    using System;

    class FindAllPassableCells
    {
        public static int[,] labytinth =
            {
                { 0, 0, 0, -1, 0, 0, 0 },
                { -1, -1, 0, -1, 0, -1, 0 },
                { 0, 0, 0, 0, 0, 0, 0 },
                { 0, -1, -1, -1, -1, -1, 0 },
                { 0, 0, 0, 0, 0, 0, 0 }
            };

        public static int count = 0;

        public static void FindPaths(int row, int col)
        {
            if (col < 0 || row < 0 || col >= labytinth.GetLength(1) || row >= labytinth.GetLength(0))
            {
                return;
            }

            if (labytinth[row, col] > 0)
            {
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
        }

        static void Main()
        {
            FindPaths(0, 0);
            Console.WriteLine(count);

            for (int col = 0; col < labytinth.GetLength(0); col++)
            {
                for (int row = 0; row < labytinth.GetLength(1); row++)
                {
                    Console.Write(labytinth[col, row] + ",  ");
                }

                Console.WriteLine();
            }
        }
    }
}
