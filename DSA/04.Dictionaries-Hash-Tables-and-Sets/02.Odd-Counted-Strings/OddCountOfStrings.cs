// Write a program that extracts from a given sequence of strings all elements that
// present in it odd number of times. Example:
// {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}

namespace _02.Odd_Counted_Strings
{
    using System;
    using System.Collections.Generic;

    public class OddCountOfStrings
    {
        public static void Main()
        {
            string[] array = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var hashSet = new HashSet<string>();

            foreach (var member in array)
            {
                if (hashSet.Contains(member))
                {
                    hashSet.Remove(member);
                }
                else
                {
                    hashSet.Add(member);
                }
            }

            Console.Write("{");
            Console.Write(string.Join(", ", hashSet));
            Console.WriteLine("}");
        }
    }
}