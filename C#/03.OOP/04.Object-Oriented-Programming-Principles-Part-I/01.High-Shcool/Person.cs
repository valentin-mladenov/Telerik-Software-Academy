using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.High_Shcool
{
    public class Person
    {
        private string name;

        public string Name
        {
            get
            { return this.name; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name must have at least several characters.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public Person(string name)
        {
            this.name = name;
        }
    }
}
