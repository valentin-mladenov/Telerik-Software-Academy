namespace _06.Phonebook
{
    using System.Collections.Generic;

    public interface IPhonebook
    {
        void AddPhoneEntry(string phone, PhonebookEntry name);

        IList<PhonebookEntry> FindByName(string name);

        IList<PhonebookEntry> FindByNameAndTown(string name, string town);
    }
}