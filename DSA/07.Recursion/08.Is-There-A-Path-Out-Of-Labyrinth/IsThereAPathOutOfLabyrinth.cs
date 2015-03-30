// Modify the above program to check whether a path exists between two cells
// without finding all possible paths. Test it over an empty 100 x 100 matrix.

namespace _08.Is_There_A_Path_Out_Of_Labyrinth
{
    using System;

    class IsThereAPathOutOfLabyrinth
    {
        public static char[,] labytinth =
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
                { '*', '*', ' ', '*', ' ', '*', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', '*', '*', '*', '*', '*', ' ' },
                { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
            };

        public static bool PathFound;

        public static void FindPaths(int row, int col)
        {
            if (col < 0 || row < 0 || col >= labytinth.GetLength(1) || row >= labytinth.GetLength(0))
            {
                return;
            }

            if (labytinth[row, col] == 'E')
            {
                PathFound = true;
                return;
            }

            if (labytinth[row, col] != '\0')
            {
                return;
            }

            labytinth[row, col] = 'V';

            FindPaths(row, col + 1); // rigth
            FindPaths(row + 1, col); // down
            FindPaths(row, col - 1); // left
            FindPaths(row - 1, col); // up
        }

        static void Main()
        {
            labytinth = new char[100, 100];
            labytinth[50, 50] = 'E';
            Console.WriteLine("This is faster with BFS, but we learn recursion now.");
            Console.WriteLine();
            FindPaths(0, 0);
            Console.WriteLine(PathFound.ToString());
        }
    }
}
