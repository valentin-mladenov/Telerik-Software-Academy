// Write a program that counts how many times each word from given text file words.txt
// appears in it. The character casing differences should be ignored. The result words
// should be ordered by their number of occurrences in the text.

namespace _03.Words_From_File
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class WordsFromTextFile
    {
        public static void Main()
        {
            Encoding encoding = Encoding.GetEncoding(1251);
            string textfile = @"..\..\words.txt";

            StreamReader streamRdr = new StreamReader(textfile, encoding);
            var sortedDictionary = new SortedDictionary<string, int>();
            
            using (streamRdr)
            {
                char[] separators = { '?', ' ', '.', ',', '!', '–' };
                string line = streamRdr.ReadLine();
                Console.WriteLine(line);
                while (line != null)
                {
                    var words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        var currentWord = word.ToLower();
                        if (!sortedDictionary.ContainsKey(currentWord))
                        {
                            sortedDictionary.Add(currentWord, 0);
                        }

                        sortedDictionary[currentWord]++;
                    }

                    line = streamRdr.ReadLine();
                    Console.WriteLine(line);
                }
            }

            foreach (var pair in sortedDictionary)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value + "times.");
            }
        }
    }
}