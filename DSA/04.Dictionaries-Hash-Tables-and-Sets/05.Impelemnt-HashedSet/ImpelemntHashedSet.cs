namespace _05.Impelemnt_HashedSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ImpelemntHashedSet
    {
        static void Main()
        {
            var hashSet = new HashedSet<string>();
            var hashSet2 = new HashedSet<string>();

            hashSet.Add("Muncho");
            Console.WriteLine("Count 1: " + hashSet.Count);
            Console.WriteLine("Value of Muncho" + hashSet.Find("Muncho"));
            hashSet.Add("Bajcho");
            hashSet.Add("Dajcho");
            hashSet.Add("Penka");
            hashSet.Add("Lazar");
            hashSet.Add("Guncho");
            hashSet.Add("Stoqn");
            hashSet.Add("Pencho");
            hashSet2.Add("Vichi");
            hashSet.Add("VIrsachI");
            hashSet.Add("Ajshe");
            hashSet2.Add("Myumyun");
            hashSet2.Add("Muncho");
            Console.WriteLine("Count 1: " + hashSet.Count);
            Console.WriteLine("Count 2: " + hashSet2.Count);
            Console.WriteLine("Contains VIrsachI: " + hashSet.Find("VIrsachI"));
            Console.WriteLine("VIrsachI deleted: " + hashSet.Remove("VIrsachI"));
            Console.WriteLine(string.Join(", ", hashSet.Values));

            var intersect = hashSet.Intersect(hashSet2);
            Console.WriteLine("Inersection: " + string.Join(", ", intersect.Values));

            var union = hashSet.Union(hashSet2);
            Console.WriteLine("Union: " + string.Join(", ", union.Values));
        }
    }
}