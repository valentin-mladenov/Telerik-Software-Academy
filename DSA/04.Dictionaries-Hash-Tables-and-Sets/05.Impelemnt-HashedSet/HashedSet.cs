namespace _05.Impelemnt_HashedSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using _04.Implement_HashTable;

    public class HashedSet<T> : IHashedSet<T>
    {
        private IHashTable<int, T> hashTable;

        public HashedSet()
        {
            this.hashTable = new HashTable<int, T>();
        }

        public void Add(T value)
        {
            this.hashTable.Add(this.Count, value);
            this.Count++;
        }

        public bool Find(T value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.hashTable.Find(i).Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.hashTable.Find(i).Equals(value))
                {
                    this.hashTable.Remove(i);
                    return true;
                }
            }

            return false;
        }

        public int Count { get; private set; }

        public void Clear()
        {
            this.hashTable = new HashTable<int, T>();
            this.Count = 0;
        }

        public IEnumerable<T> Values
        {
            get
            {
                IList<T> result = new List<T>();

                foreach (var hash in this.hashTable.Data())
                {
                    if (hash != null)
                    {
                        foreach (var keyValuePair in hash)
                        {
                            result.Add(keyValuePair.Value);
                        }
                    }
                }

                return result;
            }
        }

        public IHashedSet<T> Union(IHashedSet<T> hashedSet)
        {
            var union = this.Values.Union(hashedSet.Values);
            
            IHashedSet<T> unionSet = new HashedSet<T>();

            foreach (var value in union)
            {
                unionSet.Add(value);
            }

            return unionSet;
        }

        public IHashedSet<T> Intersect(IHashedSet<T> hashedSet)
        {
            var intersect = this.Values.Intersect(hashedSet.Values);

            IHashedSet<T> intersectSet = new HashedSet<T>();

            foreach (var value in intersect)
            {
                intersectSet.Add(value);
            }

            return intersectSet;
        }
    }
}