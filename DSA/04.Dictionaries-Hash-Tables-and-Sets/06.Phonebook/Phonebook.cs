namespace _06.Phonebook
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;
    
    public class Phonebook : IPhonebook
    {
        private readonly MultiDictionary<string, PhonebookEntry> namesAndPhoneEntries;

        public Phonebook()
        {
            this.namesAndPhoneEntries = new MultiDictionary<string, PhonebookEntry>(true);
        }

        public void AddPhoneEntry(string name, PhonebookEntry entry)
        {
            this.namesAndPhoneEntries.Add(name, entry);
        }

        public IList<PhonebookEntry> FindByName(string name)
        {
            List<PhonebookEntry> result = new List<PhonebookEntry>();

            foreach (var namesAndPhone in this.namesAndPhoneEntries)
            {
                var currentName = namesAndPhone.Key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < currentName.Length; i++)
                {
                    if (currentName[i] == name)
                    {
                        result.AddRange(namesAndPhone.Value);
                    }
                }
            }

            return result;
        }

        public IList<PhonebookEntry> FindByNameAndTown(string name, string town)
        {
            IList<PhonebookEntry> result = new List<PhonebookEntry>();

            foreach (var namesAndPhone in this.namesAndPhoneEntries)
            {
                var currentName = namesAndPhone.Key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < currentName.Length; i++)
                {
                    if (currentName[i] == name)
                    {
                        foreach (var towns in namesAndPhone.Value)
                        {
                            if (towns.Town == town)
                            {
                                result.Add(towns);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}