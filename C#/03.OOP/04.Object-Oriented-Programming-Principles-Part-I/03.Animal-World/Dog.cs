using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_World
{
    class Dog : Animals, ISound
    {
        private string breed;
        private string dogSay = "Dog says woof!!!";

        public string Breed
        {
            get { return this.breed; }
            set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The breed must have at least several characters.");
                }
                else
                {
                    this.breed = value;
                }
            }
        }

        public Dog(string name, int age, bool isMale)
            : base(name, age, isMale)
        {

        }

        public Dog(string name, int age, bool isMale, string breed)
            : base(name, age, isMale)
        {
            this.breed = breed;
        }

        public string Sound()
        {
            return this.dogSay.ToString();
        }
    }
}