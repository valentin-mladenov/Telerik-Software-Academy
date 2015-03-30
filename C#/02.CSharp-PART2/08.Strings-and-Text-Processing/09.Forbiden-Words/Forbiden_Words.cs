using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//We are given a string containing
//a list of forbidden words and a
//text containing some of these words.
//Write a program that replaces the
//forbidden words with asterisks.

class Forbiden_Words
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string[] words = { "Microsoft", "PHP", "CLR" };

        // If you want you can enter the text and words yourself. :)

        //Console.WriteLine("Please enter the text:");
        //string text = Console.ReadLine();
        //Console.Write("How many forbidden words:");
        //int howManyWords = int.Parse(Console.ReadLine());
        //string[] words = new string[howManyWords];
        //for (int i = 0; i < words.Length; i++)
        //{
        //    Console.Write("Word {0}: ", (i + 1));
        //    words[i] = Console.ReadLine();
        //}

        StringBuilder output = new StringBuilder(text);
        for (int i = 0; i < words.Length; i++)
        {
            StringBuilder asterix = new StringBuilder(words[i].Length + 1);
            asterix.Append('*', words[i].Length);
            string ala = asterix.ToString();
            output.Replace(words[i], ala);
        }
        Console.WriteLine(output);
    }
}