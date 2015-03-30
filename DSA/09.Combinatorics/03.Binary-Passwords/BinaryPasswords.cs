// 100% in BG coder

namespace _03.Binary_Passwords
{
    using System;
    using System.Linq;

    class BinaryPasswords
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var parts = input.ToCharArray();
            long count = parts.Count(t => t == '*');

            var result = (long)Math.Pow(2, count);

            Console.WriteLine(result);
        }
    }
}