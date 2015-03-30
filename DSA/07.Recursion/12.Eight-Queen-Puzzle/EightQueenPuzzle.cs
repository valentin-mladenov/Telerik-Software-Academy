// * 
// Write a recursive program to solve the "8 Queens Puzzle"
// with backtracking. Learn more at: 
// http://en.wikipedia.org/wiki/Eight_queens_puzzle

namespace _12.Eight_Queen_Puzzle
{
    using System;

    public class EightQueenPuzzle
    {
        public static void Main()
        {
            QueenSolver queenSolver = new QueenSolver(5);
            queenSolver.FindAllSolutions();
        }
    }

    public class QueenSolver
    {
        private byte[,] queens;
        private int counter;

        public QueenSolver(int size)
        {
            this.queens = new byte[size, size];
            this.counter = 0;
        }

        internal void FindAllSolutions()
        {
            this.Recursion(0);
            Console.WriteLine(this.counter);
        }

        private void Recursion(int row)
        {
            if (row == this.queens.GetLength(1))
            {
                this.counter++;
                return;
            }

            for (int col = 0; col < this.queens.GetLength(0); col++)
            {
                if (this.queens[row, col] == 0)
                {
                    this.queens[row, col] += 1;
                    this.MarkQueen(row, col);

                    //Print();

                    this.Recursion(row + 1);

                    this.queens[row, col] -= 1;
                    this.UnMarkQueen(row, col);
                }
            }
        }

        private void Print()
        {
            for (int row = 0; row < this.queens.GetLength(1); row++)
            {
                for (int col = 0; col < this.queens.GetLength(1); col++)
                {
                    Console.Write(this.queens[row, col]);
                }

                Console.WriteLine();
            }
        }

        private void MarkQueen(int row, int col)
        {
            for (int i = row; i < this.queens.GetLength(1); i++)
            {
                this.queens[i, col] += 1;
                if (col + (i - row) < this.queens.GetLength(1))
                {
                    this.queens[i, col + (i - row)] += 1;
                }

                if (col - (i - row) >= 0)
                {
                    this.queens[i, col - (i - row)] += 1;
                }
            }
        }

        private void UnMarkQueen(int row, int col)
        {
            for (int i = row; i < this.queens.GetLength(1); i++)
            {
                this.queens[i, col] -= 1;
                if (col + (i - row) < this.queens.GetLength(1))
                {
                    this.queens[i, col + (i - row)] -= 1;
                }

                if (col - (i - row) >= 0)
                {
                    this.queens[i, col - (i - row)] -= 1;
                }


            }
        }
    }
}