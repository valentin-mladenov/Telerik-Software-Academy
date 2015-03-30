using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that converts a
//string to a sequence of C#
//Unicode character literals.
//Use format strings. 

class String_To_Unicode_Literals
{
    static void Main()
    {
        string text = Console.ReadLine();
        StringBuilder output = new StringBuilder();

        foreach (char item in text)
        {
            output.AppendFormat("\\u{0:x4}", (int)item);
        }
        output.ToString();
        Console.WriteLine(output);
    }
}