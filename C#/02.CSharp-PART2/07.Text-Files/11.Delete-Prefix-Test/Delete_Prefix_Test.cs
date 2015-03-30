using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

//Write a program that deletes from a
//text file all words that start with
//the prefix "test". Words contain
//only the symbols 0...9, a...z, A…Z, _.

class Delete_Prefix_Test
{


    static void Main()
    {
        System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);
        string text = @"..\..\With-Prefix-Test.txt";
        StreamReader streamRead = new StreamReader(text, encoding);

        string withoutTest = @"..\..\Without-Prefix-Test.txt";
        StreamWriter strmWrtr = new StreamWriter(withoutTest, false, encoding);

        string withTest;
        using (strmWrtr)
        {
            using (streamRead)
            {
                withTest = streamRead.ReadLine();
                while (withTest != null)
                {
                    withTest = Regex.Replace(withTest, @"(\b)test((\d|\w|_)*)(\b)", " ");
                    strmWrtr.WriteLine(Regex.Replace(withTest, @"(\s){2,}", " "));
                    //strmWrtr.WriteLine(withTest);
                    withTest = streamRead.ReadLine();
                }
            }
        }

        Console.WriteLine("File is written!");
    }
}