using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MeetingRoomsII
    {
        // 253. Meeting Rooms II
        // Great problem, try TreeMap solution next time
        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return 0;

            Array.Sort(intervals, Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));

            // mimic a PriorityQueue with a List and binary search insert
            var pqList = new List<int[]>();
            pqList.Add(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                // The idea here is that if the new incoming meeting starts later than the earliest ending meeting's endtime,
                // then the same meeting room can be used, thus pop out the earliest ending meeting
                if (intervals[i][0] >= pqList[0][1])
                {
                    pqList.RemoveAt(0);
                }

                var insertIndex = pqList.BinarySearch(intervals[i], Comparer<int[]>.Create((a, b) => a[1].CompareTo(b[1])));
                if (insertIndex < 0)
                    pqList.Insert((insertIndex + 1) * -1, intervals[i]);
                else
                    pqList.Insert(insertIndex, intervals[i]);
            }

            return pqList.Count;
        }
    }
}
