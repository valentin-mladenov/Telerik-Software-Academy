using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_World
{
    class Cat : Animals, ISound
    {
        private string catSay = "Cat goes meow!!!";

        public Cat(string name, int age, bool isMale)
            : base(name, age, isMale)
        {

        }
        public string Sound()
        {
            return this.catSay.ToString();
        }
    }
}
