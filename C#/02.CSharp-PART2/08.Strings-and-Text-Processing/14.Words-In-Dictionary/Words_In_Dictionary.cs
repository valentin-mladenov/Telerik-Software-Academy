using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//A dictionary is stored as a sequence
//of text lines containing words and
//their explanations. Write a program
//that enters a word and translates
//it by using the dictionary. 
//Sample dictionary:
//.NET – platform for applications from Microsoft
//CLR – managed execution environment for .NET
//namespace – hierarchical organization of classes

class Words_In_Dictionary
{
    static void Main()
    {


        string text = ".NET - platform for applications from Microsoft.\nCLR - managed execution environment for .NET.\nnamespace - hierarchical organization of classes.";
        string keyWword = "CLR";

        string[] split = text.Split('\n');
        string pattern = @"(\A)" + keyWword;
        StringBuilder explanations = new StringBuilder();
        for (int i = 0; i < split.Length; i++)
        {
            string temp = (Regex.Match(split[i], pattern)).ToString();
            if (temp == keyWword)
            {
                explanations.Append(split[i]);
            }
            temp = "";
        }
        explanations.ToString();
        Console.WriteLine(explanations);
    }
}