namespace _04.Implement_HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, V> : IHashTable<K, V>, IEnumerable<KeyValuePair<K,V>>
    {
        private const int InitialValueSize = 16;

        private LinkedList<KeyValuePair<K, V>>[] dataKeyValuePairs;

        public HashTable()
        {
            this.dataKeyValuePairs = new LinkedList<KeyValuePair<K, V>>[InitialValueSize];
        }

        public int Capacity
        {
            get
            {
                return this.dataKeyValuePairs.Length;
            }
        }

        public List<K> Keys()
        {
            var list = new List<K>();
            foreach (var keyValuePairCollection in this.dataKeyValuePairs)
            {
                if (keyValuePairCollection != null)
                {
                    list.AddRange(keyValuePairCollection.Select(valuePair => valuePair.Key));
                }
            }

            return list;
        }

        public int Count { get; private set; }

        public void Add(K key, V value)
        {
            var hash = Hash(key);
            if (this.dataKeyValuePairs[hash] == null)
            {
                this.dataKeyValuePairs[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var alreadyHasKey = this.dataKeyValuePairs[hash].Any(k => k.Key.Equals(key));
            if (alreadyHasKey)
            {
                throw new ArgumentException("Key allready exists");
            }

            var pair = new KeyValuePair<K, V>(key, value);
            this.dataKeyValuePairs[hash].AddLast(pair);
            this.Count++;

            if (this.Count >= (this.Capacity / 4) * 3)
            {
                this.ResizeAndWrithValues();
            }
        }

        public bool ContainsKey(K key)
        {
            var hash = Hash(key);
            if (this.dataKeyValuePairs[hash] == null)
            {
                return false;
            }

            var pairs = this.dataKeyValuePairs[hash];
            return pairs.Any(pair => pair.Key.Equals(key));
        }

        public V Find(K key)
        {
            var hash = Hash(key);
            if (this.dataKeyValuePairs[hash] == null)
            {
                throw new ArgumentException("No such Key.");
            }

            var pairs = this.dataKeyValuePairs[hash];
            foreach (var keyValuePair in pairs)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    return keyValuePair.Value;
                }
            }
            throw new ArgumentException("No such Key.");
        }

        public bool Remove(K key)
        {
            var hash = Hash(key);
            if (this.dataKeyValuePairs[hash] == null)
            {
                throw new ArgumentException("No such Key.");
            }

            var pairs = this.dataKeyValuePairs[hash];
            foreach (var keyValuePair in pairs)
            {
                if (keyValuePair.Key.Equals(key))
                {
                    pairs.Remove(keyValuePair);
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            this.dataKeyValuePairs = new LinkedList<KeyValuePair<K, V>>[this.Capacity];
        }

        private void ResizeAndWrithValues()
        {
            // cache
            var currentData = this.dataKeyValuePairs;
            //resize
            this.dataKeyValuePairs = new LinkedList<KeyValuePair<K, V>>[this.Capacity * 2];
            // add and reset Count
            this.Count = 0;
            foreach (var keyValuePairCollection in currentData)
            {
                if (keyValuePairCollection != null)
                {
                    foreach (var valuePair in keyValuePairCollection)
                    {
                        this.Add(valuePair.Key, valuePair.Value);
                    }
                }
            }
        }

        private int Hash(K key)
        {
            var hash = key.GetHashCode();
            hash %= this.Capacity;
            hash = Math.Abs(hash);
            return hash;
        }

        public LinkedList<KeyValuePair<K, V>>[] Data()
        {
            return this.dataKeyValuePairs;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var keyValuePairCollection in this.dataKeyValuePairs)
            {
                if (keyValuePairCollection != null)
                {
                    foreach (var valuePair in keyValuePairCollection)
                    {
                        yield return valuePair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}