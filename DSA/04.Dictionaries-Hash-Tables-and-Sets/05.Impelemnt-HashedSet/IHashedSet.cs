namespace _05.Impelemnt_HashedSet
{
    using System.Collections.Generic;

    public interface IHashedSet<T>
    {
        void Add(T value);

        bool Find(T value);

        bool Remove(T value);

        int Count { get; }

        void Clear();

        IEnumerable<T> Values { get; }

        IHashedSet<T> Union(IHashedSet<T> hashedSet);

        IHashedSet<T> Intersect(IHashedSet<T> hashedSet);
    }
}