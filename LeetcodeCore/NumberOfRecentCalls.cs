using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RecentCounter
    {
        // 933. Number of Recent Calls
        private readonly ArrayList _list;

        public RecentCounter()
        {
            _list = new ArrayList();
        }

        public int Ping(int t)
        {
            var index = _list.BinarySearch(t - 3000);
            _list.Add(t);
            if (index < 0)
            {
                return _list.Count - ((index + 1) * -1);
            }
            else
            {
                return _list.Count - index;
            }
        }
    }
}
