using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MeetingRoomsIIWithRoomName
    {
        // A variance of the [253. Meeting Rooms II] problem
        public string MinMeetingRooms(int[][] intervals, int rooms)
        {
            if (intervals == null || intervals.Length == 0)
                return "";
            if (rooms <= 0)
                return "impossible";

            var queue = new Queue<char>();
            var roomName = 'A';
            for (int i = 0; i < rooms; i++)
            {
                queue.Enqueue(roomName);
                roomName++;
            }
            var sb = new StringBuilder();

            Array.Sort(intervals, Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));

            var pq = new PriorityQueue<(int[],char)>(Comparer<(int[], char)>.Create((a, b) => a.Item1[1].CompareTo(b.Item1[1])));
            var currRoom = queue.Dequeue();
            pq.Push((intervals[0], currRoom));
            sb.Append(currRoom);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] >= pq.Peek().Item1[1])
                {
                    var temp = pq.Pop();
                    queue.Enqueue(temp.Item2);
                    var nextRoom = queue.Dequeue();
                    sb.Append(nextRoom);
                    pq.Push((intervals[i], nextRoom));
                }
                else
                {
                    if (queue.Count > 0)
                    {
                        var nextRoom = queue.Dequeue();
                        sb.Append(nextRoom);
                        pq.Push((intervals[i], nextRoom));
                    }
                    else
                    {
                        return "impossible";
                    }
                }
            }

            return sb.ToString();
        }
    }
}
