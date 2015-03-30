// 100 points in BGcoder

namespace _02.DogeCoin
{
    using System;

    class DogeCoin
    {
        private static void Main()
        {
            var matrixSize = Console.ReadLine();
            var coins = int.Parse(Console.ReadLine());
            var rowCol = matrixSize.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var rows = int.Parse(rowCol[0]);
            var cols = int.Parse(rowCol[1]);
            var dogeMatrix = new int[rows, cols];
            for (int coin = 0; coin < coins; coin++)
            {
                var coinPosition = Console.ReadLine();
                var CoinRowCol = coinPosition.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                dogeMatrix[int.Parse(CoinRowCol[0]), int.Parse(CoinRowCol[1])]++;
            }

            for (int col = 1; col < cols; col++)
            {
                dogeMatrix[0, col] += dogeMatrix[0, col - 1];
            }

            for (int row = 1; row < rows; row++)
            {
                dogeMatrix[row, 0] += dogeMatrix[row - 1, 0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (dogeMatrix[row, col - 1] > dogeMatrix[row - 1, col])
                    {
                        dogeMatrix[row, col] += dogeMatrix[row, col - 1];
                    }
                    else
                    {
                        dogeMatrix[row, col] += dogeMatrix[row - 1, col];
                    }
                }
            }

            Console.WriteLine(dogeMatrix[rows - 1, cols - 1]);
        }
    }
}