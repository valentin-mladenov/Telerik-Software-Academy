// * A text file phones.txt holds information about people, their town and phone number:
// Mimi Shmatkata          | Plovdiv  | 0888 12 34 56
// Kireto                  | Varna    | 052 23 45 67
// Daniela Ivanova Petrova | Karnobat | 0899 999 888
// Bat Gancho              | Sofia    | 02 946 946 946
// Duplicates can occur in people names, towns and phone numbers.
// Write a program to read the phones file and execute a sequence of
// commands given in the file commands.txt:
// find(name) – display all matching records by given name (first, middle, last or nickname)
// find(name, town) – display all matching records by given name and town

namespace _06.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class PhonebookApp
    {
        private static char[] separators = { '|', '(', '"', ',', ')' };

        public static List<string> HandleCommandParameters(string command)
        {
            List<string> result = command.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(result[i]))
                {
                    result.RemoveAt(i);
                }
            }

            return result;
        }

        public static void Main()
        {
            Encoding encoding = Encoding.GetEncoding(1251);
            string textfile = @"..\..\phones.txt";
            var streamReader = new StreamReader(textfile, encoding);
            var phonebook = new Phonebook();

            using (streamReader)
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    var phoneElements = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    var phoneEntry = new PhonebookEntry(
                        phoneElements[0].Trim(),
                        phoneElements[1].Trim(),
                        phoneElements[2].Trim());

                    phonebook.AddPhoneEntry(phoneElements[0].Trim(), phoneEntry);

                    line = streamReader.ReadLine();
                }
            }

            textfile = @"..\..\commands.txt";
            streamReader = new StreamReader(textfile, encoding);

            using (streamReader)
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    var result = new List<PhonebookEntry>();
                    var commandElements = HandleCommandParameters(line);

                    if (commandElements.Count == 2)
                    {
                        result = phonebook.FindByName(commandElements[1]).ToList();
                    }
                    else if (commandElements.Count == 3)
                    {
                        result = phonebook.FindByNameAndTown(commandElements[1], commandElements[2]).ToList();
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Too many arguments.");
                    }

                    foreach (var phonebookEntry in result)
                    {
                        Console.WriteLine(phonebookEntry.ToString());
                    }

                    Console.WriteLine();
                    line = streamReader.ReadLine();
                }
            }
        }
    }
}