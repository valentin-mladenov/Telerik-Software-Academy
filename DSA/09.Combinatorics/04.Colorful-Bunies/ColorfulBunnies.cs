// 42% in BGcoder i don't know why. The algo looks correct.
// I try a lot border cases still correct output, but?!

namespace _04.Colorful_Bunies
{
    using System;

    class ColorfulBunnies
    {
        static void Main()
        {
            var input = int.Parse(Console.ReadLine());

            int[] bunnies = new int[input];
            int bunnyCount = 0;
            for (int i = 0; i < input; i++)
            {
                bunnies[i] = int.Parse(Console.ReadLine());

                if (i == 0 || bunnies[i] != bunnies[i - 1])
                {
                    bunnyCount += bunnies[i];
                    bunnyCount++;
                }
            }

            Console.WriteLine(bunnyCount);
        }
    }
}