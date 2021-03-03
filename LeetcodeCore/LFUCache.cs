using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LFUCache
    {
        // 460. LFU Cache
        // One nodeDict, one countDict with separate LinkedLists for every count
        // TODO: Try refactor and encapsulate some utility methods next time
        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<Tuple<int, int, int>>> _nodeDict; // Tuple<key, value, count>
        private readonly Dictionary<int, LinkedList<Tuple<int, int, int>>> _countDict;
        private int _min;

        public LFUCache(int capacity)
        {
            _capacity = capacity;
            _min = 0;
            _nodeDict = new Dictionary<int, LinkedListNode<Tuple<int, int, int>>>(_capacity);
            _countDict = new Dictionary<int, LinkedList<Tuple<int, int, int>>>();
        }

        public int Get(int key)
        {
            if (_capacity == 0)
                return -1;

            if (_nodeDict.TryGetValue(key, out var node))
            {
                var currLlist = _countDict.GetValueOrDefault(node.Value.Item3);
                currLlist.Remove(node);
                if (node.Value.Item3 == _min && currLlist.Count == 0)
                    _min++;
                var newNode = new LinkedListNode<Tuple<int, int, int>>(new Tuple<int, int, int>(node.Value.Item1, node.Value.Item2, node.Value.Item3 + 1));
                _nodeDict.Remove(key);
                _nodeDict.Add(key, newNode);
                if (_countDict.TryGetValue(newNode.Value.Item3, out var nextList))
                {
                    nextList.AddFirst(newNode);
                }
                else
                {
                    var newList = new LinkedList<Tuple<int, int, int>>();
                    newList.AddFirst(newNode);
                    _countDict.Add(newNode.Value.Item3, newList);
                }
                return node.Value.Item2;
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0)
                return;

            if (_nodeDict.TryGetValue(key, out var node))
            {
                var currLlist = _countDict.GetValueOrDefault(node.Value.Item3);
                currLlist.Remove(node);
                if (node.Value.Item3 == _min && currLlist.Count == 0)
                    _min++;
                var newNode = new LinkedListNode<Tuple<int, int, int>>(new Tuple<int, int, int>(key, value, node.Value.Item3 + 1));
                _nodeDict.Remove(key);
                _nodeDict.Add(key, newNode);
                if (_countDict.TryGetValue(newNode.Value.Item3, out var nextList))
                {
                    nextList.AddFirst(newNode);
                }
                else
                {
                    var newList = new LinkedList<Tuple<int, int, int>>();
                    newList.AddFirst(newNode);
                    _countDict.Add(newNode.Value.Item3, newList);
                }
            }
            else
            {
                if (_nodeDict.Count == _capacity)
                {
                    var removeList = _countDict.GetValueOrDefault(_min);
                    var removeNode = removeList.Last;
                    removeList.RemoveLast();
                    _nodeDict.Remove(removeNode.Value.Item1);
                }
                var newNode = new LinkedListNode<Tuple<int, int, int>>(new Tuple<int, int, int>(key, value, 1));
                _nodeDict.Add(key, newNode);
                _min = 1;
                if (_countDict.TryGetValue(_min, out var nextList))
                {
                    nextList.AddFirst(newNode);
                }
                else
                {
                    var newList = new LinkedList<Tuple<int, int, int>>();
                    newList.AddFirst(newNode);
                    _countDict.Add(_min, newList);
                }
            }
        }
    }
}
