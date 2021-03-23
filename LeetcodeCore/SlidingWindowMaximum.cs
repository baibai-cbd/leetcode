using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SlidingWindowMaximum
    {
        // 239. Sliding Window Maximum
        // This PQ solution is pretty bad, look below for better solutoin(Monotonic Queue)
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var i = 0;
            var j = k-1;
            var resultList = new List<int>();
            var pq = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) =>
            {
                if (a.Item2.CompareTo(b.Item2) != 0)
                    return a.Item2.CompareTo(b.Item2);
                else
                    return a.Item1.CompareTo(b.Item1);
            }));

            for (int x = i; x <= j; x++)
            {
                pq.Add((x, nums[x]));
            }

            resultList.Add(pq.Max.Item2);

            for (int y = j + 1; y < nums.Length; y++)
            {
                pq.Remove((i, nums[i]));
                i++;
                pq.Add((y, nums[y]));
                resultList.Add(pq.Max.Item2);
            }

            return resultList.ToArray();
        }

        // Monotonic Queue
        // Very nice solution
        public int[] MaxSlidingWindow2(int[] nums, int k)
        {
            var i = 0;
            var j = k - 1;
            var resultList = new List<int>();
            var queue = new LinkedList<(int, int)>();

            for (int x = i; x <= j; x++)
            {
                MonotonicPush(queue, nums[x]);
            }

            resultList.Add(queue.First.Value.Item1);

            for (int y = j + 1; y < nums.Length; y++)
            {
                MonotonicPop(queue);
                MonotonicPush(queue, nums[y]);
                resultList.Add(queue.First.Value.Item1);
            }

            return resultList.ToArray();
        }

        private void MonotonicPush(LinkedList<(int, int)> linkedList, int value)
        {
            var newNode = new LinkedListNode<(int, int)>((value, 1));
            while (linkedList.Count > 0 && linkedList.Last.Value.Item1 < newNode.Value.Item1)
            {
                newNode.Value = (newNode.Value.Item1, newNode.Value.Item2 + linkedList.Last.Value.Item2);
                linkedList.RemoveLast();
            }
            linkedList.AddLast(newNode);
        }

        private int MonotonicPop(LinkedList<(int, int)> linkedList)
        {
            if (linkedList.Count == 0)
                throw new InvalidOperationException();

            if (linkedList.First.Value.Item2 == 1)
            {
                var result = linkedList.First;
                linkedList.RemoveFirst();
                return result.Value.Item1;
            }
            else
            {
                linkedList.First.Value = (linkedList.First.Value.Item1, linkedList.First.Value.Item2 - 1);
                return linkedList.First.Value.Item1;
            }
        }
    }
}
