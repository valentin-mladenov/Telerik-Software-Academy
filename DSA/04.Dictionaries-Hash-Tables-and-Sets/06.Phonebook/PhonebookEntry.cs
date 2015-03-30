namespace _06.Phonebook
{
    using System.Text;

    public class PhonebookEntry
    {
        public PhonebookEntry(string name, string town, string phone)
        {
            this.Name = name;
            this.Phone = phone;
            this.Town = town;
        }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Town { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("Name: {0}, Town: {1}, Phone: {2}", this.Name, this.Town, this.Phone);

            return result.ToString();
        }
    }
}