using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_World
{
    class AnimalWorldMain
    {
        static void AveregeAge(Animals[] arr)
        {
            double sum = 0;
            double count = 0;
            foreach (var item in arr)
            {
                sum += item.Age;
                count++;
            }
            double result = sum / count;
            Console.WriteLine("Averege age of this animal is: {0}", Math.Round(result, 2));
        }

        static void Main()
        {
            Kitten kitty = new Kitten("jiji", 6,false);
            Fox fox = new Fox("Foxy", 4, false);
            TomCat tomcat = new TomCat("Tom", 3, true);
            Cat cat = new Cat("Morgan", 5, true);
            Dog dog = new Dog("Sharo", 4, true, "Karakachanka");

            Kitten[] kitties = new Kitten[]
            {
                new Kitten("Jiji", 2, false), new Kitten("Pisi-Pisi", 9, false),
                new Kitten("Patza", 6, false), new Kitten("Kote", 4, false),
                new Kitten("Murrri", 5, false), new Kitten("Mote", 3, false)
            };
            AveregeAge(kitties);

            Fox[] foxies = new Fox[]
            {
                new Fox("Nqnq", 4, false), new Fox("Dum", 1, false),
                new Fox("Zade", 3, false), new Fox("Keke", 2, true),
                new Fox("Hozi", 6, true), new Fox("Papa", 7, false)
            };
            AveregeAge(foxies);

            Dog[] dogies = new Dog[]
            {
                new Dog("Sharo", 4, false), new Dog("Jhony", 11, false),
                new Dog("Tzacho", 13, false), new Dog("Nebul", 2, true),
                new Dog("Balkan", 6, true, "Karakachanka"), new Dog("Mishka", 7, false)
            };
            AveregeAge(dogies);
        }
    }
}
