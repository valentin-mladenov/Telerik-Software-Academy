// Implement the data structure "hash table" in a class HashTable<K,T>.
// Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[])
// with initial capacity of 16. When the hash table load runs over 75%, perform resizing
// to 2 times larger capacity. Implement the following methods and properties:
// Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys.
// Try to make the hash table to support iterating over its elements with foreach.

namespace _04.Implement_HashTable
{
    using System;

    public class ImplementHashTable
    {
        public static void Main()
        {
            var hashTable = new HashTable<string, int>();

            hashTable.Add("Muncho", 456);
            Console.WriteLine("Capacity: " + hashTable.Capacity);
            Console.WriteLine("Count: " + hashTable.Count);
            Console.WriteLine("Value of Muncho" + hashTable.Find("Muncho"));
            hashTable.Add("Bajcho", 456);
            hashTable.Add("Dajcho", 456);
            hashTable.Add("Penka", 456);
            hashTable.Add("Lazar", 356);
            hashTable.Add("Guncho", 456);
            hashTable.Add("Stoqn", 456);
            hashTable.Add("Pencho", 247);
            hashTable.Add("Vichi", 456);
            hashTable.Add("VIrsachI", 456);
            hashTable.Add("Ajshe", 456);
            hashTable.Add("Myumyun", 456);
            Console.WriteLine("Capacity: " + hashTable.Capacity);
            Console.WriteLine("Count: " + hashTable.Count);
            Console.WriteLine("Contains VIrsachI: " + hashTable.ContainsKey("VIrsachI"));
            Console.WriteLine("VIrsachI deleted: " + hashTable.Remove("VIrsachI"));
            Console.WriteLine(string.Join(", ", hashTable.Keys()));
        }
    }
}