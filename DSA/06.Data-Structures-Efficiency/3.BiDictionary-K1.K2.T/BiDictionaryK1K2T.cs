namespace _3.BiDictionary_K1.K2.T
{
    using System;
    using System.Collections.Generic;

    internal class BiDictionaryK1K2T
    {
        private static void Main()
        {
            var biDictionary = new BiDictionary<int, string, string>();
            for (int i = 0; i < 10; i++)
            {
                biDictionary.Add(i, "a" + i, string.Format("entry{0}", i));
            }

            ICollection<string> found = new List<string>();
            biDictionary.Add(0, "a0", "duplicatedEntry0");
            found = biDictionary.SerchByKey1(0);
            PrintCollection(found);

            biDictionary.Add(1, "a2", "duplicate In Three Dictionaries");
            found = biDictionary.SerchByBothKeys(1, "a2");
            PrintCollection(found);

            found = biDictionary.SerchByBothKeys(5, "a5");
            PrintCollection(found);

            biDictionary.Add(100, "99", "only value for keys K1 100, K2 99");
            PrintCollection(biDictionary.SerchByKey1(100));
            PrintCollection(biDictionary.SerchByKey2("99"));

            biDictionary.RemoveByKeyK1(1);
            found = biDictionary.SerchByKey1(1);
            Console.WriteLine("Found items after removing with first key: {0}", found.Count > 0);

            biDictionary.RemoveByKeyK2("a0");
            found = biDictionary.SerchByKey2("a0");
            Console.WriteLine("Found items after removing second key: {0}", found.Count > 0);

            found = biDictionary.SerchByKey1(0);
            Console.WriteLine("Found items with first key 0: {0}", found.Count > 0);
            PrintCollection(found);

            biDictionary.RemoveByBothkeys(100, "99");
            found = biDictionary.SerchByBothKeys(100, "99");
            Console.WriteLine("Found items after removing with both keys: {0}", found.Count > 0);
        }

        private static void PrintCollection<V>(ICollection<V> found)
        {
            Console.WriteLine(string.Join(", ", found));

        }
    }
}