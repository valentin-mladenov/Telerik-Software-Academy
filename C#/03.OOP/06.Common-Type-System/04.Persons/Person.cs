using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Persons
{
    class Person
    {
        private string fullName;
        private byte? age;

        public string Name
        {
            get { return this.fullName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name must have at least several characters.");
                }
                else
                {
                    this.fullName = value;
                }
            }
        }

        public byte? Age
        {
            get { return this.age; }
            private set 
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Invalid age. It should be in the range between 0 and 124.");
                }
                else
                {
                    this.age = value;
                } 
            }
        }

        public Person(string name)
        {
            this.fullName = name;
        }
        public Person(string name, byte? age)
            : this(name)
        {
            this.age = age;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("Name: " + this.fullName);
            if (age == null)
            {
                str.Append(", Age: Unknown.");
            }
            else
            {
                str.Append(", Age: " + this.age + ".");
            }

            return str.ToString();
        }
    }
}
