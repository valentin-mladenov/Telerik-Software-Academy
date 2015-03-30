using System;
using System.IO;

//Write a program that concatenates
//two text files into another text file.


class Concatenate_2_Txt_To_One
{
    static StreamWriter Write(StreamReader str1, StreamWriter str2)
    {
        // For unknown reasons the file din't Read/Writte to the end the second time
        using (str1)
        {
            string line = str1.ReadLine();
            while (line != null)
            {
                str2.WriteLine(line);
                line = str1.ReadLine();
            }
        }        
        return str2;
    }

    static void Main()
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);

        string textfile1 = @"..\..\marmalad1.txt";
        StreamReader streamRdr1 = new StreamReader(textfile1, encoding);

        string textfile2 = @"..\..\marmalad2.txt";
        StreamReader streamRdr2 = new StreamReader(textfile2, encoding);

        string textfile1Plus2 = @"..\..\marmalad1Plus2.txt";
        StreamWriter streamWrtr = new StreamWriter(textfile1Plus2, true, encoding);

        streamWrtr = Write(streamRdr1, streamWrtr);
        streamWrtr = Write(streamRdr2, streamWrtr);

        Console.WriteLine("File is written!");
    }
}