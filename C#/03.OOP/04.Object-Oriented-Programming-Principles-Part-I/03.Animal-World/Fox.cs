using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_World
{
    class Fox : Animals, ISound
    {
        private string foxSay = "What does ths fox say?\nRing-ding-ding-ding-dingeringeding!";

        public Fox(string name, int age, bool isMale)
            : base(name, age, isMale)
        {

        }
        public string Sound()
        {
            return this.foxSay;
        }
    }
}
