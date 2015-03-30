using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//You are given a text. Write a program
//that changes the text in all regions
//surrounded by the tags <upcase> and
//</upcase> to uppercase. The tags
//cannot be nested. 

class Uppercase_Within_Tags
{
    static List<int> UpperCasing(string casing,string text)
    {
        List<int> list = new List<int>();
        int index = -1;
        while (true)
        {
            index = text.IndexOf(casing, index + 1);
            if (index == -1)
            {
                break;
            }
            list.Add(index);
        }
        return list;
    }

    static void Main()
    {
        //string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string text = Console.ReadLine();
        string start = "<upcase>";
        string end = "</upcase>";

        char[] charText= text.ToCharArray();
        List<int> indexStart = UpperCasing(start, text);
        List<int> indexEnd = UpperCasing(end, text);

        string[] getStrings = new string[indexEnd.Count];
        string[] toUpper = new string[indexEnd.Count];

        for (int i = 0; i < charText.Length; i++)
        {
            if (i<indexStart.Count)
            {
                getStrings[i] = text.Substring(indexStart[i] + 8, (indexEnd[i] - indexStart[i] - 8));
                toUpper[i] = getStrings[i].ToUpper();
            }
            else
            {
                break;
            }
        }

        StringBuilder textToUp = new StringBuilder(text);
        textToUp.Replace(start, "");
        textToUp.Replace(end,"");

        for (int i = 0; i < indexStart.Count; i++)
        {
            textToUp.Replace(getStrings[i], toUpper[i]);
        }
        textToUp.ToString();

        Console.WriteLine(textToUp);
    }
}