using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Write a program that extracts
//from given HTML file its title
//(if available), and its body 
//text without the HTML tags. 


class No_HTML_Tags
{
    static Encoding encoding = Encoding.GetEncoding(1251);

    static void Main()
    {        
        StreamReader textRead = new StreamReader(@"..\..\HTML-File.html", encoding);         
        string  htmlFile = "";

        using (textRead)
        {
            htmlFile = textRead.ReadToEnd();
        }

        StringBuilder tempArr = new StringBuilder();
        string pattern = @"(?<=^|>)[^><]+?(?=<|$)";
        foreach (Match item in Regex.Matches(htmlFile, pattern))
        {
            if (!String.IsNullOrWhiteSpace(item.Value))
            {
                tempArr.Append(item);
            }
        }
        Console.WriteLine(tempArr.ToString());
    }
}