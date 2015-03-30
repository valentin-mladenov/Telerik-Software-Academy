// 100 points in BGcoder.

namespace Quadronacci_Rectangle
{
    using System;
    using System.Text;

    class QuadronacciRectangle
    {
        static void Main()
        {
            long [] array = new long[4];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = long.Parse(Console.ReadLine());
            }

            long rows = long.Parse(Console.ReadLine());
            long cols = long.Parse(Console.ReadLine());

            long firstN = array[0];
            long secondN = array[1];
            long thirdN = array[2];
            long fourthN = array[3];
            long sumN = 0;

            long[] arrExit  = new long[rows * cols];

            for (int i = 0; i < array.Length; i++)
            {
                arrExit[i] = array[i];
            }

            for (long i = array.Length; i < arrExit.Length; i++)
            {
                sumN = fourthN + firstN + secondN + thirdN;
                firstN = secondN;
                secondN = thirdN;
                thirdN = fourthN;
                fourthN = sumN;
                arrExit[i] = fourthN;
            }

            long[,] result = new long[rows, cols];
            var index = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = arrExit[index];
                    index++;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                var str = new StringBuilder();
                for (int col = 0; col < cols; col++)
                {
                    str.Append(string.Format("{0} ", result[row, col]));
                }

                Console.WriteLine(str.ToString().Trim());
            }
        }
    }
}
