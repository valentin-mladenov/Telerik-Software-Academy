// Write a program to calculate the "Minimum Edit Distance" (MED) between two words. MED(x, y) is the minimal
// sum of costs of edit operations used to transform x to y. Sample costs are given below:
// cost (replace a letter) = 1
// cost (delete a letter) = 0.9
// cost (insert a letter) = 0.8
// Example: x = "developer", y = "enveloped" -> cost = 2.7 
// delete ‘d’:  "developer" -> "eveloper", cost = 0.9
// insert ‘n’:  "eveloper" -> "enveloper", cost = 0.8
// replace ‘r’ -> ‘d’:  "enveloper" -> "enveloped", cost = 1


namespace _02.Minimum_Edit_Distance
{
    using System;

    internal class MinimumEditDistance
    {
        private const decimal Delete = 0.9m;
        private const decimal Insert = 0.8m;
        private const decimal Replace = 1.0m;

        private static void Main()
        {
            var word1 = "enveloped";
            var word2 = "developer";

            var result = EditDistanceDynamic(word1, word2);

            Console.WriteLine(result);
        }

        private static decimal EditDistanceDynamic(string pattern, string input)
        {
            decimal[,] wordMatrix = new decimal[2, input.Length + 1];

            for (int i = 0; i < input.Length; i++)
            {
                wordMatrix[0, i] = i * Delete;
            }

            int count = 0;
            for (int index = 1; index <= pattern.Length; index++)
            {
                int currentRow = index % 2;
                int prevousRow = 1 - currentRow;
                for (int j = 1; j <= input.Length; j++)
                {
                    var cost = (input[j - 1] == pattern[index - 1]) ? 0 : Replace;

                    var minCostDeletePattern = wordMatrix[currentRow, index - 1] + Delete;
                    var minCostMiddle = wordMatrix[prevousRow, j - 1] + cost;
                    var minCostInsertPattern = wordMatrix[prevousRow, j] + Insert;

                    wordMatrix[currentRow, j] = Math.Min(
                        Math.Min(minCostInsertPattern, minCostDeletePattern),
                        minCostMiddle);
                }

                count = index - 1;
            }

            return wordMatrix[1 - (count % 2), input.Length];
        }
    }
}