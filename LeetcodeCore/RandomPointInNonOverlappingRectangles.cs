using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RandomPointInNonOverlappingRectangles
    {
        // 497. Random Point in Non-overlapping Rectangles

        private readonly Random _random;
        private readonly int[][] _rects;
        private readonly SortedDictionary<int, int> _dict;
        private readonly int _area;

        public RandomPointInNonOverlappingRectangles(int[][] rects)
        {
            _rects = rects;
            _random = new Random();
            _dict = new SortedDictionary<int, int>();
            _area = 0;
            for (int i = 0; i < _rects.Length; i++)
            {
                _area += (rects[i][2] - rects[i][0] + 1) * (rects[i][3] - rects[i][1] + 1);
                _dict.Add(_area, i);
            }
        }

        public int[] Pick()
        {
            int randInt = _random.Next(_area);
            int diff = int.MaxValue;
            foreach (var key in _dict.Keys)
            {
                var currDiff = key - randInt;
                if (currDiff < diff && currDiff > 0)
                {
                    diff = currDiff;
                }
            }
            var foundKey = randInt + diff;
            _dict.TryGetValue(foundKey, out int foundRect);
            var rect = _rects[foundRect];
            int x = rect[0] + (diff - 1) % (rect[2] - rect[0] + 1);
            int y = rect[1] + (diff - 1) / (rect[2] - rect[0] + 1);
            return new int[] { x, y };
        }
    }
}
