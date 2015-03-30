using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_And_Workers
{
    class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name must have at least several characters.");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name must have at least several characters.");
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public override string ToString()
        {
            return this.firstName + " " + this.lastName; ;
        }
    }
}