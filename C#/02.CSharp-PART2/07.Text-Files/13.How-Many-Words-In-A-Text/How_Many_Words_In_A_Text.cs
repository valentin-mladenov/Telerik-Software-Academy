using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.IO;
using System.Text.RegularExpressions;

//Write a program that reads a list of
//words from a file words.txt and finds
//how many times each of the words is
//contained in another file test.txt.
//The result should be written in the
//file result.txt and the words should
//be sorted by the number of their
//occurrences in descending order.
//Handle all possible exceptions
//in your methods.


class How_Many_Words_In_A_Text
{
    static Encoding encoding = Encoding.GetEncoding(1251);

    static void Main()
    {
        try
        {
            string input = @"..\..\Text.txt";
            StreamReader textRead = new StreamReader(input, encoding);
            string wordsToCheck = @"..\..\Words.txt";
            StreamReader removeRead = new StreamReader(wordsToCheck, encoding);

            string output = @"..\..\Words-Checked.txt";
            StreamWriter strmWrtr = new StreamWriter(output, false, encoding);

            List<string> words = new List<string>();
            using (removeRead)
            {
                string line = removeRead.ReadLine();
                while (line != null)
                {
                    words.Add(line);
                    line = removeRead.ReadLine();
                }
            }

            int[] count = new int[words.Count];
            string text = "";
            using (textRead)
            {
                text = textRead.ReadToEnd();
            }
            using (strmWrtr)
            {

                for (int i = 0; i < count.Length; i++)
                {
                    string word = words[i];
                    count[i] = Regex.Matches(text, word).Count;
                    strmWrtr.WriteLine("word {0} repeats {1} times.", word, count[i]);
                }
            }
        }

        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}