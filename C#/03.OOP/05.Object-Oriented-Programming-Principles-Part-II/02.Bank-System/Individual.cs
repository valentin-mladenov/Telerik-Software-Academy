using System;
using System.Linq;

namespace _02.Bank_System
{
    class Individual : Customer
    {
        private string fullName;
        private byte age;
        private string egn;

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must have at least several characters.");
                }
                else
                {
                    this.fullName = value;
                }
            }
        }

        public byte Age
        {
            get { return this.age; }
            private set 
            {
                if (value <= 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Incorrect age.");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public string EGN
        {
            get { return this.egn; }
            private set 
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("EGN can't be empty.");
                }
                else if (value.Length!=10)
                {
                    throw new ArgumentOutOfRangeException("EGN has exactly 10 digits.");
                }
                else
                {
                    long temp = long.Parse(value); // Exeption trowing.
                    this.egn = value;
                }
            }
        }

        public Individual(string fullName, byte age, string egn)
        {
            this.age = age;
            this.egn = egn;
            this.fullName = fullName;
        }
    }
}