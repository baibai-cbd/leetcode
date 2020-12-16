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
}
