using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bank_System
{
    class Company :Customer
    {
        private string firmName;
        private string bulstat;

        public string Bulstat
        {
            get { return this.bulstat; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Bulstat number can't be empty.");
                }
                else if (value.Length > 15 || value.Length<13)
                {
                    throw new ArgumentOutOfRangeException("Bulstat number is between 13 and 15 digits.");
                }
                else
                {
                    long temp = long.Parse(value); // Exeption trowing.
                    this.bulstat = value;
                }
            }
        }

        public string FirmName
        {
            get { return this.firmName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must have at least several characters.");
                }
                else
                {
                    this.firmName = value;
                }
            }
        }

        public Company(string firmName, string bulstat)
        {
            this.bulstat = bulstat;
            this.firmName = firmName;
        }
    }
}
