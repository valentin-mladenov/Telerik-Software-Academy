using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_World
{
    class TomCat : Cat, ISound
    {
        private string tomcatSay = "Tomcat says Mrrrrrrrr!!!";

        public TomCat(string name, int age, bool isMale)
            : base(name, age, isMale)
        {
            if (isMale == false)
            {
                throw new ArgumentException("Tomcats are males!?");
            }
        }
        public string Sound()
        {
            return this.tomcatSay.ToString();
        }
    }
}
