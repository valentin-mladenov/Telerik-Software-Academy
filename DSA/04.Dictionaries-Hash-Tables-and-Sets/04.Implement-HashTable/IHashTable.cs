namespace _04.Implement_HashTable
{
    using System.Collections.Generic;

    public interface IHashTable <K, V>
    {
        void Add(K key, V value);

        V Find(K key);

        bool Remove(K key);

        void Clear();

        int Capacity { get; }

        List<K> Keys();

        LinkedList<KeyValuePair<K, V>>[] Data();
    }
}