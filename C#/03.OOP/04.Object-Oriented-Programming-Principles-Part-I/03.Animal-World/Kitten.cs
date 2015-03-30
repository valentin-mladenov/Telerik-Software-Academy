using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_World
{
    class Kitten : Cat, ISound
    {
        private string kittySay = "Kitten says myau!!!";

        public Kitten(string name, int age, bool isMale)
            : base(name, age, isMale)
        {
            if (isMale == true)
            {
                throw new ArgumentException("Kittens are females!?");
            }
        }
        public string Sound()
        {
            return this.kittySay.ToString();
        }
    }
}
