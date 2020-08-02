using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class DesignHashSet
    {
        // 705. Design HashSet
        private const int seed = 33;
        private readonly IList<int>[] hashBuckets;
        public DesignHashSet()
        {
            hashBuckets = new IList<int>[seed];
        }

        public void Add(int key)
        {
            var mod = key % seed;
            if (hashBuckets[mod] == null)
            {
                hashBuckets[mod] = new List<int>();
                hashBuckets[mod].Add(key);
            }
            else
            {
                if (hashBuckets[mod].Contains(key))
                    return;
                else
                    hashBuckets[mod].Add(key);
            }
        }

        public void Remove(int key)
        {
            var mod = key % seed;
            if (hashBuckets[mod] == null)
                return;

            var index = hashBuckets[mod].IndexOf(key);

            if (index == -1)
                return;
            else
                hashBuckets[mod].RemoveAt(index);
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            var mod = key % seed;
            if (hashBuckets[mod] == null)
                return false;
            else
                return hashBuckets[mod].Contains(key);
        }
    }
}
