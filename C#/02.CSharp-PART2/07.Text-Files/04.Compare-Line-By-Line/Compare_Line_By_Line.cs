using System;
using System.IO;

//Write a program that compares
//two text files line by line and
//prints the number of lines that
//are the same and the number of
//lines that are different. Assume
//the files have equal number of lines.


class Compare_Line_By_Line
{
    static void Main()
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);

        string textfile1 = @"..\..\marmalad1.txt";
        StreamReader streamRdr1 = new StreamReader(textfile1, encoding);

        string textfile2 = @"..\..\marmalad2.txt";
        StreamReader streamRdr2 = new StreamReader(textfile2, encoding);

        string textOne = "";
        string textTwo = "";
        int lineSame = 0;
        int lineDiferent = 0;

        while (textOne!= null | textTwo != null)
        {            
            textOne = streamRdr1.ReadLine();
            textTwo = streamRdr2.ReadLine();          

            if (textTwo == textOne)
            {
               lineSame++;
            }
            else
	        {
                lineDiferent++;
	        }
        }
        streamRdr1.Close();
        streamRdr2.Close();

        Console.WriteLine("Same lines are {0}, diferent are {1} from total {2}", lineSame, lineDiferent, lineDiferent + lineSame);
    }
}