using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LRUCache
    {
        // 146. LRU Cache
        // TODO: try thread-safe implementation next time
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

    public class LRUCacheO1
    {
        // 146. LRU Cache
        // O(1) solution
        private readonly int _capacity;
        private readonly LinkedList<Tuple<int, int>> _linkedList; // Have to get key from the LinkedListNode, that's why the KV tuple is stored in LinkedListNode
        private readonly Dictionary<int, LinkedListNode<Tuple<int, int>>> _nodeDict;

        public LRUCacheO1(int capacity)
        {
            _capacity = capacity;
            _linkedList = new LinkedList<Tuple<int,int>>();
            _nodeDict = new Dictionary<int, LinkedListNode<Tuple<int, int>>>(capacity);
        }

        public int Get(int key)
        {
            if (_nodeDict.TryGetValue(key, out var node))
            {
                _linkedList.Remove(node);
                _linkedList.AddFirst(node);
                return node.Value.Item2;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (_nodeDict.TryGetValue(key, out var node))
            {
                node.Value = new Tuple<int, int>(key, value);
                _linkedList.Remove(node);
                _linkedList.AddFirst(node);
            }
            else
            {
                if (_nodeDict.Count == _capacity)
                {
                    _nodeDict.Remove(_linkedList.Last.Value.Item1); // Have to get key from the LinkedListNode, that's why the KV tuple is stored in LinkedListNode
                    _linkedList.RemoveLast();
                }
                var newNode = new LinkedListNode<Tuple<int, int>>(new Tuple<int, int>(key, value));
                _linkedList.AddFirst(newNode);
                _nodeDict.Add(key, newNode);
            }
        }
    }
}
