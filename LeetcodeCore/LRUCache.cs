using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LRUCache
    {
        // 146. LRU Cache
        // TODO: work on O(1) solution next time
        private readonly int _capacity;
        private readonly LinkedList<int> _linkedList;
        private readonly Dictionary<int, int> _valueDict;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _linkedList = new LinkedList<int>();
            _valueDict = new Dictionary<int, int>(capacity);
        }

        public int Get(int key)
        {
            if (_valueDict.TryGetValue(key, out int value))
            {
                _linkedList.Remove(key);
                _linkedList.AddFirst(key);
                return value;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (_valueDict.ContainsKey(key))
            {
                _valueDict[key] = value;
                _linkedList.Remove(key);
                _linkedList.AddFirst(key);
            }
            else
            {
                if (_valueDict.Count == _capacity)
                {
                    var last = _linkedList.Last;
                    _linkedList.RemoveLast();
                    _valueDict.Remove(last.Value);
                }
                _valueDict.Add(key, value);
                _linkedList.AddFirst(key);
            }
        }
    }
}
