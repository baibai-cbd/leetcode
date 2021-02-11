using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MeetingRooms
    {
        // 252. Meeting Rooms
        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals.Length <= 1)
                return true;

            Array.Sort(intervals, new Comparison<int[]>((a, b) => a[0].CompareTo(b[0])));

            var lastMeeting = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < lastMeeting[1])
                    return false;

                lastMeeting = intervals[i];
            }

            return true;
        }
    }
}
