using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MedianFinder
    {
        // 295. Find Median from Data Stream
        // TODO: follow up on range of input strictly within [0, 100], use bucket sort idea
        /** initialize your data structure here. */
        private readonly List<int> _data;
        private int _medianIndex0;
        private int _medianIndex1;

        public MedianFinder()
        {
            _data = new List<int>();
            _medianIndex0 = 0;
            _medianIndex1 = 0;
        }

        public void AddNum(int num)
        {
            var index = _data.BinarySearch(num);
            if (index < 0)
                index = (index + 1) * -1;

            if (IsDataCountEven())
            {
                _medianIndex0 = _medianIndex1;
                _data.Insert(index, num);
            }
            else
            {
                _medianIndex1++;
                _data.Insert(index, num);
            }
        }

        public double FindMedian()
        {
            return IsDataCountEven() ? (_data[_medianIndex0]+_data[_medianIndex1]) / (double)2 : (double)_data[_medianIndex0];
        }

        private bool IsDataCountEven()
        {
            return _data.Count % 2 == 0;
        }
    }


    public class MedianFinder2
    {
        // This solution uses 2 PriorityQueue with opposite sort order,
        // ensures the median is between the Min of the larger queue and the Max of the smaller queue
        private readonly PriorityQueue<int> _smallQueue;
        private readonly PriorityQueue<int> _largeQueue;
        private bool _even;

        public MedianFinder2()
        {
            _even = true;
            _smallQueue = new PriorityQueue<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            _largeQueue = new PriorityQueue<int>();
        }

        public void AddNum(int num)
        {
            if (_even)
            {
                _largeQueue.Push(num);
                var temp = _largeQueue.Pop();
                _smallQueue.Push(temp);
                _even = !_even;
            }
            else
            {
                _smallQueue.Push(num);
                var temp = _smallQueue.Pop();
                _largeQueue.Push(temp);
                _even = !_even;
            }
        }

        public double FindMedian()
        {
            return _even ? (_smallQueue.Peek() + _largeQueue.Peek()) / (double)2 : (double) _smallQueue.Peek();
        }
    }
}
