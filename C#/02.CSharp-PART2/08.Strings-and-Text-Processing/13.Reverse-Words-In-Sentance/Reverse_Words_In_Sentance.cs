using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//Write a program that reverse
//the words in given sentence.
//Example: 
//"C# is not C++, not PHP and not Delphi!"  
//"Delphi not and PHP, not C++ not is C#!".

class Reverse_Words_In_Sentance
{
    static string[] lasts = { ".", "!", "?", ":", ";" };

    static void Main()
    {
        //string sentance = "C# is not C++, not PHP and not Delphi!";
        string sentance = Console.ReadLine();

        string lastChar = "";
        for (int i = 0; i < lasts.Length; i++)
        {
            if (sentance.EndsWith(lasts[i]))
	        {
                lastChar = lasts[i];
	        }
        }
        
        string pattern = @"\s|[,.!?:;]";
        string[] parts = Regex.Split(sentance, pattern);

        List<string> words = new List<string>();
        List<int> coma = new List<int>();
        for (int i = 0; i < parts.Length-1; i++)
        {
            if (parts[i] == "")
            {
                coma.Add(i);
            }
            else
            {
                words.Add(parts[i]);
            }
        }
        words.Reverse();

        StringBuilder reverse = new StringBuilder(sentance.Length);
        int space = 0;
        List<int> spaceComa = new List<int>();
        for (int i = 0; i < words.Count; i++)
        {
            for (int j = 0; j < coma.Count; j++)
            {
                if (coma[j]==i)
                {
                    reverse.Append(", ");
                    string temp = reverse.ToString();
                    space = temp.IndexOf(',', space);
                    spaceComa.Add(space);
                }
            }
            if (i == words.Count-1)
	        {
                reverse.Append(words[i]);
	        }
            else
            {
                reverse.Append(words[i] + " ");
            }
        }        
        reverse.Append(lastChar);

        for (int i = 0; i < spaceComa.Count; i++)
        {
            reverse.Remove(spaceComa[i] - 1, 1);
        }
        reverse.ToString();

        Console.WriteLine(reverse);
    }
}