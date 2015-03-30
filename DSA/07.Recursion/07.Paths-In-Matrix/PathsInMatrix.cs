// We are given a matrix of passable and non-passable cells. Write a
// recursive program for finding all paths between two cells in the matrix.

namespace _07.Paths_In_Matrix
{
    using System;

    class PathsInMatrix
    {
        public static char[,] labitinth =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
                { '*', '*', ' ', '*', ' ', '*', ' ' },
                { ' ', ' ', ' ', ' ', ' ', 'E', ' ' },
                { ' ', '*', '*', '*', '*', '*', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
            };

        public static int count = 0;

        public static void FindPaths(int row, int col)
        {
            if (col < 0 || row < 0 || col >= labitinth.GetLength(1) || row >= labitinth.GetLength(0))
            {
                return;
            }

            if (labitinth[row, col] == 'E')
            {
                count++;
                return;
            }

            if (labitinth[row, col] != ' ')
            {
                return;
            }

            labitinth[row, col] = 'V';

            FindPaths(row, col + 1); // rigth
            FindPaths(row + 1, col); // down
            FindPaths(row, col - 1); // left
            FindPaths(row - 1, col); // up

            labitinth[row, col] = ' ';
        }

        static void Main()
        {
            FindPaths(0, 0);
            Console.WriteLine(count);
        }
    }
}
