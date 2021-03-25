using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ShortestUnsortedContinuousSubarray
    {
        // 581. Shortest Unsorted Continuous Subarray
        // TODO: There is a better solution with similar idea
        public int FindUnsortedSubarray(int[] nums)
        {
            var n = nums.Length;
            if (n <= 1)
                return 0;

            var indexHead = nums.Length;
            var indexTail = -1;
            var queueAsc = new LinkedList<(int, int)>();
            var queueDesc = new LinkedList<(int, int)>();

            for (int i = 0; i < nums.Length; i++)
            {
                // check from front, non-increasing elements
                MonotonicPushWithFlag(queueDesc, nums[i], false);
                if (queueDesc.Last.Value.Item2 > 1)
                {
                    indexHead = Math.Min(indexHead, i - (queueDesc.Last.Value.Item2 - 1));
                }
                // check from back, increasing elements(when looked backwards)
                MonotonicPushWithFlag(queueAsc, nums[n-1-i], true);
                if (queueAsc.Last.Value.Item2 > 1)
                {
                    indexTail = Math.Max(indexTail, n-1-i + (queueAsc.Last.Value.Item2 - 1));
                }
            }

            return indexHead > indexTail ? 0 : (indexTail - indexHead + 1);
        }

        private void MonotonicPushWithFlag(LinkedList<(int, int)> linkedList, int value, bool ascFlag)
        {
            if (ascFlag)
            {
                var newNode = new LinkedListNode<(int, int)>((value, 1));
                while (linkedList.Count > 0 && linkedList.Last.Value.Item1 < value)
                {
                    newNode.Value = (newNode.Value.Item1, newNode.Value.Item2 + linkedList.Last.Value.Item2);
                    linkedList.RemoveLast();
                }
                linkedList.AddLast(newNode);
            }
            else
            {
                var newNode = new LinkedListNode<(int, int)>((value, 1));
                while (linkedList.Count > 0 && linkedList.Last.Value.Item1 > value)
                {
                    newNode.Value = (newNode.Value.Item1, newNode.Value.Item2 + linkedList.Last.Value.Item2);
                    linkedList.RemoveLast();
                }
                linkedList.AddLast(newNode);
            }
        }
    }
}
