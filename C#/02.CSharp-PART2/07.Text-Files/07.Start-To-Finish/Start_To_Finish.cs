using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//Write a program that replaces all
//occurrences of the substring "start"
//with the substring "finish" in a text
//file. Ensure it will work with large
//files (e.g. 100 MB).

//Modify the solution of the previous
//problem to replace only whole words
//(not substrings).



class Start_To_Finish
{
    static void Main()
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);
        string text = @"..\..\Start.txt";
        StreamReader streamRead = new StreamReader(text, encoding);

        string start;
        using (streamRead)
        {
            start = streamRead.ReadToEnd();
        }        

        StringBuilder final = new StringBuilder(start);
        final.Replace(" start ", " finish ");
        final.Replace(" start,", " finish,");
        final.Replace(" start.", " finish.");
        final.Replace(" start!", " finish!");
        final.Replace(" start?", " finish?");
        string rsult = final.ToString();

        string finish = @"..\..\Finish.txt";
        StreamWriter strmWrtr = new StreamWriter(finish, false, encoding);

        using (strmWrtr)
        {
            strmWrtr.Write(rsult);
        }

        Console.WriteLine("File is written!");
    }
}