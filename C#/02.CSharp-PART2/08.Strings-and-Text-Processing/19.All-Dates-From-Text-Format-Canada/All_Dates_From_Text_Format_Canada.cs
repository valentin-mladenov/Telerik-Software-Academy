using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

//Write a program that extracts from
//a given text all dates that match
//the format DD.MM.YYYY. Display them
//in the standard date format for Canada.


class All_Dates_From_Text_Format_Canada
{
    static void Main()
    {
        string text = "23.10.2015, wertufrtyult, gesryd fg ,2652, erystryuryjd 22.11.2015, 03.10.2025, wer hyrdfuyh asgdfbv aerhtjfgb 13.05.2115";
        string[] separators = { " ", "\t", "," };
        string[] textArray = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        List<DateTime> valid = new List<DateTime>();
        string pattern = @"[0-9]{2}.[0-9]{2}.[0-9]{4}";

        for (int i = 0; i < textArray.Length; i++)
        {
            
            textArray[i] = textArray[i].TrimStart();
            bool validate = Regex.IsMatch(textArray[i], pattern);
            if (validate == true)
            {
                valid.Add(DateTime.Parse(textArray[i]));
            }
        }

        foreach (DateTime item in valid)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
            Console.WriteLine("Date format french Canada:  {0}", item.ToString(CultureInfo.GetCultureInfo("fr-CA").DateTimeFormat.LongDatePattern));
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            Console.WriteLine("Date format english Canada: {0}",item.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.LongDatePattern));
            Console.WriteLine();
        }
    }
}