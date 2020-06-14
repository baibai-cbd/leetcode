using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class RandomizedSet
    {
        // 380. Insert Delete GetRandom O(1)

        IList<int> _array;
        IDictionary<int, int> _dict;
        Random _random;

        public RandomizedSet()
        {
            _array = new List<int>();
            _dict = new Dictionary<int, int>();
            _random = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            var contain = _dict.TryGetValue(val, out int value);
            if (contain)
                return false;
            _dict.Add(val, _array.Count);
            _array.Add(val);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            var contain = _dict.TryGetValue(val, out int location);
            if (!contain) return false;

            if (location < _array.Count - 1)
            { // not the last one than swap the last one with this val
                int lastone = _array.ElementAt(_array.Count - 1);
                _array[location] = lastone;
                _dict[lastone] = location;
            }
            _dict.Remove(val);
            _array.RemoveAt(_array.Count - 1);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return _array.ElementAt(_random.Next(0, _array.Count));
        }
    }
}
