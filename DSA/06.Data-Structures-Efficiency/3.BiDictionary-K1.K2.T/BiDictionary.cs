namespace _3.BiDictionary_K1.K2.T
{
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private readonly MultiDictionary<KeyValuePair<K1, K2>, T> triDict;
        private readonly OrderedMultiDictionary<K2, K1> keysK2K1;
        private readonly OrderedMultiDictionary<K1, K2> keysK1K2; 

        public BiDictionary()
        {
            this.triDict = new MultiDictionary<KeyValuePair<K1, K2>, T>(true);
            this.keysK1K2 = new OrderedMultiDictionary<K1, K2>(true);
            this.keysK2K1 = new OrderedMultiDictionary<K2, K1>(true);
        }

        public void Add(K1 keyK1, K2 keyK2, T value)
        {

            this.keysK1K2.Add(keyK1, keyK2);
            this.keysK2K1.Add(keyK2, keyK1);
            var keyPair12 = new KeyValuePair<K1, K2>(keyK1, keyK2);
            this.triDict.Add(keyPair12, value);
        }

        public ICollection<T> SerchByKey1(K1 keyK1)
        {
            var keyK2Collection = this.keysK1K2[keyK1];

            return keyK2Collection.SelectMany(keyK2 => this.SerchByBothKeys(keyK1, keyK2)).ToList();
        }

        public ICollection<T> SerchByKey2(K2 keyK2)
        {
            var keyK1Collection = this.keysK2K1[keyK2];

            return keyK1Collection.SelectMany(keyK1 => this.SerchByBothKeys(keyK1, keyK2)).ToList();
        }

        public void RemoveByKeyK1(K1 keyK1)
        {
            var keyK2Collection = this.keysK1K2[keyK1];
            this.keysK1K2.Remove(keyK1);

            foreach (var keyK2 in keyK2Collection)
            {
                var keysPair = new KeyValuePair<K1, K2>(keyK1, keyK2);
                this.triDict.Remove(keysPair);
                this.keysK2K1.Remove(keyK2, keyK1);
            }
        }

        public void RemoveByKeyK2(K2 keyK2)
        {
            var keyK1Collection = this.keysK2K1[keyK2];
            this.keysK2K1.Remove(keyK2);

            foreach (var keyK1 in keyK1Collection)
            {
                var keysPair = new KeyValuePair<K1, K2>(keyK1, keyK2);
                this.triDict.Remove(keysPair);
                this.keysK1K2.Remove(keyK1, keyK2);
            }
        }

        public void RemoveByBothkeys(K1 keyK1, K2 keyK2)
        {
            var keysPair = new KeyValuePair<K1, K2>(keyK1, keyK2);
            this.triDict.Remove(keysPair);
            this.keysK1K2.Remove(keyK1, keyK2);
            this.keysK2K1.Remove(keyK2, keyK1);
        }

        public ICollection<T> SerchByBothKeys(K1 keyK1, K2 keyK2)
        {
            var keysPair = new KeyValuePair<K1, K2>(keyK1, keyK2);
            var result = this.triDict[keysPair];
            return result;
        }
    }
}