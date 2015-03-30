using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Write a program for extracting all
//email addresses from given text.
//All substrings that match the format
//<identifier>@<host>…<domain> 
//should be recognized as emails.

class EMAILs_From_Text
{
    static void Main()
    {

        //With REGEX i don't like it.
        string text = "svirka@kaval.com, esrthjfghj sladurana@duduk.net aerhgd, -123--@usa.net, test.test123@en.some-host.12345.com, .ala.@bala.com, test@-host.com, user@.test.ru, user@test.ru., alabala@, user@host, @eu.net";
        

        string[] separators = { " ", "\t", "," };
        string[] textArray = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine(text);
        Console.WriteLine();
        string pattern = @"^([a-zA-Z0-9_\-][a-zA-Z0-9_\-\.]{0,49})" + @"@(([a-zA-Z0-9][a-zA-Z0-9\-]{0,49}\.)+[a-zA-Z]{2,4})$";
        List<string> valid = new List<string>();

        for (int i = 0; i < textArray.Length; i++)
        {
            textArray[i] = textArray[i].TrimStart();
            bool validate = Regex.IsMatch(textArray[i], pattern);
            if (validate == true)
            {
                valid.Add(textArray[i]);
            }
        }

        foreach (string item in valid)
        {
            Console.WriteLine(item);
        }
    }
}