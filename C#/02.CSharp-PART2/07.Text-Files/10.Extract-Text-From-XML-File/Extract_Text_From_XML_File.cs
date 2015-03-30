using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//Write a program that extracts from
//given XML file all the text without
//the tags. Example:

//<?xml version="1.0"><student><name>
//Pesho</name><age>21</age><interests
//count="3"><interest> Games</instrest>
//<interest>C#</instrest><interest>
//Java</instrest></interests></student>


internal class Extract_Text_From_XML_File
{
    private static void Main()
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);
        string textfile = @"..\..\XML-Extract.xml";
        StreamReader streamRdr = new StreamReader(textfile, encoding);

        string fileXML;
        using (streamRdr)
        {
            fileXML = streamRdr.ReadToEnd();
        }
        char[] words = fileXML.ToCharArray();
        string withoutTags = "";


        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == '>')
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[j] != '<')
                    {
                        withoutTags += words[j];
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        Console.WriteLine(withoutTags);
    }
}