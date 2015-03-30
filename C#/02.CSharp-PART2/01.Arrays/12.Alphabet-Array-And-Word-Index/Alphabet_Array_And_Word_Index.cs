using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that creates an array
//containing all letters from the alphabet
//(A-Z). Read a word from the console and print
//the index of each of its letters in the array.


class Alphabet_Array_And_Word_Index
{
    static void Main()
    {
        char[] letters = new char[53];
        for (int i = 1; i < letters.Length; i++)
        {
            letters[i] = (char)(i + 64);
        }

        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (letters[j] == word[i])
                {
                    Console.WriteLine("Letter {0} has index: {1}", word[i], j);
                    break;
                }
            }
        }
    }
}