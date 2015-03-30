using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;


//Write a program that removes from a
//text file all words listed in given
//another text file. Handle all possible
//exceptions in your methods.


class Remove_Words_Handle_Exeptions
{
    static Encoding encoding = Encoding.GetEncoding(1251);

    static void Main()
    {
        try
        {
            string text = @"..\..\Text.txt";
            StreamReader textRead = new StreamReader(text, encoding);
            string wordsToRemove = @"..\..\Words-To-Remove.txt";
            StreamReader removeRead = new StreamReader(wordsToRemove, encoding);

            string writheText = @"..\..\Removed-Words-From-Text.txt";
            StreamWriter strmWrtr = new StreamWriter(writheText, false, encoding);

            //string wordsToRemove = @"\b(" + string.Join("|", File.ReadAllLines("../../Words-To-Remove.txt")) + @")\b";     
            //using (textRead)
            //{
            //    using (strmWrtr)
            //    {
            //        string line = textRead.ReadLine();
            //        while (line != null)
            //        {
            //            strmWrtr.WriteLine(Regex.Replace(line, wordsToRemove, String.Empty));
            //            line = textRead.ReadLine();
            //        }
            //    }
            //}

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

            string start;
            using (textRead)
            {
                start = textRead.ReadToEnd();
            }

            StringBuilder textWithWords = new StringBuilder(start);
            for (int i = 0; i < words.Count; i++)
            {
                textWithWords.Replace(words[i], "");
            }

            using (strmWrtr)
            {
                strmWrtr.WriteLine(textWithWords);
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