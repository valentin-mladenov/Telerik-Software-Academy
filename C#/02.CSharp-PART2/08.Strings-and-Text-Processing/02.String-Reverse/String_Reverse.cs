using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Write a program that reads a string,
//reverses it and prints the result at
//the console.
//Example: "sample"  "elpmas".


class String_Reverse
{
    static void Main()
    {
        string text = Console.ReadLine();

        char[] charText = text.ToCharArray();
        Array.Reverse(charText);

        string reversed = "";

        for (int i = 0; i < charText.Length; i++)
        {
            reversed += charText[i];
        }

        Console.WriteLine(reversed);
    }
}