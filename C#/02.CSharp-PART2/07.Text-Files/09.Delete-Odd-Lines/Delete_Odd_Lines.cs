using System;
using System.IO;

//Write a program that deletes
//from given text file all odd
//lines. The result should be
//in the same file.


class Delete_Odd_Lines
{
    static void Main()
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);
        string textfile = @"..\..\marmalad.txt";
        StreamReader streamRdr = new StreamReader(textfile, encoding);

        string line = "";

        using (streamRdr)
        {
            int oddLine = 0;
            line = streamRdr.ReadLine();
            string odd = "";
            while (odd != null)
            {
                oddLine++;
                if ((oddLine & 1) == 0)
                {
                    line = line + streamRdr.ReadLine() + " \n";
                }
                else
                {
                    odd = streamRdr.ReadLine();
                }
            }
        }       

        string[] separators = { "\n" };
        string[] lines = line.Split(separators, System.StringSplitOptions.None);
        
        string textfile1 = @"..\..\marmalad.txt";
        StreamWriter strmWrtr = new StreamWriter(textfile1);

        using (strmWrtr)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                strmWrtr.WriteLine(lines[i]);
            }
        }
        Console.WriteLine("File is written!");
    }
}