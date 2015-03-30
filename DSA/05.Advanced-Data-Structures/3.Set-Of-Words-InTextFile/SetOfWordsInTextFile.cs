// Write a program that finds a set of words (e.g. 1000 words)
// in a large text (e.g. 100 MB text file). Print how many times
// each word occurs in the text.
// Hint: you may find a C# trie in Internet

// I try to generate random words, but with no luck. 
// Probubly made several mistakes in implemetation.
// The program hangs be patient.
// So far din't find any word very odd.
namespace _3.Set_Of_Words_InTextFile
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public class SetOfWordsInTextFile
    {
        private static void GenWords(Node node, HashSet<Letter>[] sets, int currentArrayIndex, List<string> wordsFound)
        {
            if (currentArrayIndex < sets.Length)
            {
                foreach (var edge in node.Edges)
                {
                    if (sets[currentArrayIndex].Contains(edge.Key))
                    {
                        if (edge.Value.IsTerminal)
                        {
                            wordsFound.Add(edge.Value.Word);
                        }

                        GenWords(edge.Value, sets, currentArrayIndex + 1, wordsFound);
                    }
                }
            }
        }

        private static void Main()
        {
            const int minArraySize = 3;
            const int maxArraySize = 4;
            const int setCount = 1000;
            const bool generateRandomInput = true;
            Console.WriteLine("Program hangs be patient.");
            var wordsFound = new List<string>();

            var trie = new Trie();
            string[] str = File.ReadAllLines(@"..\..\text.txt");
            trie.ReadFile(str);
            var watch = new Stopwatch();
            var trials = 1000;
            var wordCountSum = 0;
            var rand = new Random(37);

            for (int t = 0; t < trials; t++)
            {
                HashSet<Letter>[] sets;
                if (generateRandomInput)
                {
                    sets = new HashSet<Letter>[setCount];
                    for (int i = 0; i < setCount; i++)
                    {
                        sets[i] = new HashSet<Letter>();
                        var size = minArraySize + rand.Next(maxArraySize - minArraySize + 1);
                        while (sets[i].Count < size)
                        {
                            sets[i].Add(Letter.Chars[rand.Next(Letter.Chars.Length)]);
                        }
                    }
                }
                else
                {
                    sets = new HashSet<Letter>[]
                               {
                                   new HashSet<Letter>(new Letter[] { 'P', 'Q', 'R', 'S' }),
                                   new HashSet<Letter>(new Letter[] { 'A', 'B', 'C' }),
                                   new HashSet<Letter>(new Letter[] { 'T', 'U', 'V' }),
                                   new HashSet<Letter>(new Letter[] { 'M', 'N', 'O' })
                               };
                }

                watch.Start();
                
                for (int i = 0; i < sets.Length - 1; i++)
                {
                    GenWords(trie.Root, sets, i, wordsFound);
                }
                watch.Stop();
                wordCountSum += wordsFound.Count;

                if (generateRandomInput)
                {
                    foreach (var word in wordsFound)
                    {
                        Console.WriteLine(word);
                    }
                }
            }

            Console.WriteLine("Elapsed per trial = {0}", new TimeSpan(watch.Elapsed.Ticks / trials));
            Console.WriteLine("Average word count per trial = {0:0.0}", (float)wordCountSum / trials);
            
            foreach (var word in wordsFound)
            {
                Console.WriteLine(word);
            }
        }
    }
}