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



        // Solution 2
        // Splitting the start, end events and sort altogether
        public int MinMeetingRooms2(int[][] intervals)
        {

            var events = new List<Tuple<int, int>>();
            foreach (var i in intervals)
            {
                events.Add(new Tuple<int, int>(i[0], 1));
                events.Add(new Tuple<int, int>(i[1], -1));
            }

            events.Sort(Comparer<Tuple<int, int>>.Create((a, b) =>
            {
                if (a.Item1.CompareTo(b.Item1) != 0)
                    return a.Item1.CompareTo(b.Item1);
                else
                    return a.Item2.CompareTo(b.Item2);
            }));

            var stack = new Stack<Tuple<int, int>>();
            var max = 0;
            foreach (var e in events)
            {
                stack.Push(e);
                if (stack.Peek().Item2 == -1)
                {
                    stack.Pop();
                    stack.Pop();
                }
                max = Math.Max(max, stack.Count);
            }

            return max;
        }


        // Solution 3
        // Splitting the start, end events and using 2 arrays for sort, very skillful solution
        public int MinMeetingRooms3(int[][] intervals)
        {
            int[] starts = new int[intervals.Length];
            int[] ends = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                starts[i] = intervals[i][0];
                ends[i] = intervals[i][1];
            }
            Array.Sort(starts);
            Array.Sort(ends);
            int rooms = 0;
            int endsItr = 0;
            for (int i = 0; i < starts.Length; i++)
            {
                if (starts[i] < ends[endsItr])
                    rooms++;
                else
                    endsItr++;
            }
            return rooms;
        }


        // Solution 4
        // Java with TreeMap
        //public int minMeetingRooms(Interval[] intervals)
        //{
        //    Map<Integer, Integer> map = new TreeMap<>();
        //    for (Interval itl : intervals)
        //    {
        //        map.put(itl.start, map.getOrDefault(itl.start, 0) + 1);
        //        map.put(itl.end, map.getOrDefault(itl.end, 0) - 1);
        //    }
        //    int room = 0, k = 0;
        //    for (int v : map.values())
        //        k = Math.max(k, room += v);
        //
        //    return k;
        //}

        // Solution 5
        // Using my own PriorityQueue implementation
        public int MinMeetingRooms5(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return 0;

            Array.Sort(intervals, Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));

            var pq = new PriorityQueue<int[]>(Comparer<int[]>.Create((a, b) => a[1].CompareTo(b[1])));
            pq.Push(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] >= pq.Peek()[1])
                    pq.Pop();

                pq.Push(intervals[i]);
            }

            return pq.Count;
        }
    }
}
