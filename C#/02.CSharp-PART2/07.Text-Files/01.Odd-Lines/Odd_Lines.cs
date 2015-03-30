using System;
using System.IO;

//Write a program that reads
//a text file and prints on
//the console its odd lines.
using System.Text;

internal class Odd_Lines
{
    private static void Main()
    {
        Encoding encoding = Encoding.GetEncoding(1251);
        string textfile = @"..\..\marmalad.txt";
        Console.WriteLine("The contents of the every odd line in the file {0} is:", textfile);

        StreamReader streamRdr = new StreamReader(textfile, encoding);
        using (streamRdr)
        {
            int oddLine = 0;
            string line = streamRdr.ReadLine();
            while (line != null)
            {
                oddLine++;
                if ((oddLine & 1) == 0)
                {
                    line = streamRdr.ReadLine();
                }
                else
                {
                    Console.WriteLine("Line {0}: {1}", oddLine, line);
                    line = streamRdr.ReadLine();
                }
            }
        }
    }
}