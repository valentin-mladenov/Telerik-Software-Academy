using System;
using System.IO;

//Write a program that reads a
//text file and inserts line
//numbers in front of each of
//its lines. The result should
//be written to another text file.


class Insert_Line_Numbers
{
    static StreamWriter WrithePlusLineNumber(StreamReader strRdr, StreamWriter strWrtr)
    {
        // For unknown reasons the file din't Read/Writte to the end
        using (strRdr)
        {
            int lineNumber = 0;
            string line = strRdr.ReadLine();

            while (line != null)
            {
                lineNumber++;
                strWrtr.WriteLine("Line {0}: {1}", lineNumber, line);
                line = strRdr.ReadLine();
            }
        }
        return strWrtr;
    }

    static void Main()
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);
        string textfile = @"..\..\marmalad.txt";
        StreamReader streamRdr = new StreamReader(textfile, encoding);

        string withLine = @"..\..\marmalad-With-Line-Numbers.txt";
        StreamWriter streamWrtr = new StreamWriter(withLine, false, encoding);

        streamWrtr = WrithePlusLineNumber(streamRdr, streamWrtr);
        Console.WriteLine("File is written!");
    }
}