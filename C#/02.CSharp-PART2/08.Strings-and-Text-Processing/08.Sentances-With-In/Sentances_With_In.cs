using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//Write a program that extracts from
//a given text all sentences containing
//given word.
//Example: The word is "in".
//Consider that the sentences are
//separated by "." and the words
//– by non-letter symbols.


class Sentances_With_In
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "are";

        // If you want you can enter the text and word yourself. :)
        //string text = Console.ReadLine();
        //string word = Console.ReadLine();
        
        string[] sent = text.Split('.');
        StringBuilder sentances = new StringBuilder();
        string pattern = @"(\b)" + word + @"(\b)";
        for (int i = 0; i < sent.Length; i++)
        {
            string temp = (Regex.Match(sent[i], pattern)).ToString();
            if (temp == word)
            {
                sentances.Append(sent[i]+".");
            }
            temp = "";         
        }
        sentances.ToString();
        Console.WriteLine(sentances);
    }
}