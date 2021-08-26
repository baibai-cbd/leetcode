using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class FindTheLongestValidObstacleCourseAtEachPosition
    {
        // 1964. Find the Longest Valid Obstacle Course at Each Position
        // This solution combines two parts from [34. Find First and Last Position of Element in Sorted Array] and [300. Longest Increasing Subsequence]
        // good solution to understand
        public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
        {

            var course = new int[obstacles.Length];
            var result = new int[obstacles.Length];

            result[0] = 1;
            course[0] = obstacles[0];
            var currLength = 1;

            for (int i = 1; i < obstacles.Length; i++)
            {
                var index = BinarySearchRightBound(course, 0, currLength - 1, obstacles[i]);

                course[index] = obstacles[i];
                result[i] = index + 1;

                if (index == currLength)
                    currLength++;
            }

            return result;
        }

        private int BinarySearchRightBound(int[] nums, int left, int right, int target)
        {
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] == target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }
    }
}
