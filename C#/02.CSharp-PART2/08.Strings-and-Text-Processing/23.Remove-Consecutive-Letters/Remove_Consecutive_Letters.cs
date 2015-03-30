using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a string
//from the console and replaces all
//series of consecutive identical
//letters with a single one. 

class Remove_Consecutive_Letters
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaafffffffwwwwwwwwwwwdsxxxxxxxxxxxxxgggggggggw";
        Console.WriteLine(text);

        char[] textArr = text.ToCharArray();
        StringBuilder tempArr = new StringBuilder();

        for (int i = 0; i < textArr.Length-1; i++)
        {
            if (textArr[i] != textArr[i + 1])
            {
                tempArr.Append(textArr[i]);
            }
        }
        if (textArr[textArr.Length-2] != textArr[textArr.Length-1])
        {
            tempArr.Append(textArr[textArr.Length - 1]);
        }
        Console.WriteLine(tempArr.ToString());
    }
}