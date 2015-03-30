using System;
using System.Collections.Generic;
using System.IO;

//Write a program that reads a text file
//containing a list of strings, sorts
//them and saves them to another text file.
//Example:
//    Ivan			George
//    Peter	____\	Ivan
//    Maria		/	Maria
//    George		Peter


class Sort_Strings
{
    static void Main()
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);
        string unsorted = @"..\..\UnsortedStrings.txt";
        StreamReader streamRead = new StreamReader(unsorted, encoding);

        List<string> sorting = new List<string>();

        using (streamRead)
        {            
            string line = streamRead.ReadLine();
            while (line != null)
            {
                sorting.Add(line);
                line = streamRead.ReadLine();
            }
        }
        sorting.Sort();

        string sorted = @"..\..\SortedStrings.txt";
        StreamWriter strmWrtr = new StreamWriter(sorted, false, encoding);

        using (strmWrtr)
        {
            for (int i = 0; i < sorting.Count; i++)
            {
                strmWrtr.WriteLine(sorting[i]);
            }
        }
        Console.WriteLine("File is written!");
    }
}