using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_World
{
    class Animals
    {
        private string name;
        private bool isMale;
        private int age;

        public bool IsMale
        {
            get { return this.isMale; }
            private set { this.isMale = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must have at least several characters.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Animals(string name, int age, bool isMale)
        {
            this.name = name;
            this.age = age;
            this.isMale = isMale;
        }
    }
}