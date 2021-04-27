using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class KthLargestElementInAStream
    {
        // 703. Kth Largest Element in a Stream
        private readonly PriorityQueue<int> _pq;
        private readonly int _k;

        public KthLargestElementInAStream(int k, int[] nums)
        {
            _k = k;
            _pq = new PriorityQueue<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (_pq.Count < _k)
                {
                    _pq.Push(nums[i]);
                }
                else
                {
                    if (_pq.Peek() < nums[i])
                    {
                        _pq.Pop();
                        _pq.Push(nums[i]);
                    }
                }
            }
        }

        public int Add(int val)
        {
            if (_pq.Count < _k)
            {
                _pq.Push(val);
                return _pq.Peek();
            }
            else
            {
                if (_pq.Peek() < val)
                {
                    _pq.Pop();
                    _pq.Push(val);
                }
                return _pq.Peek();
            }
        }
    }
}
