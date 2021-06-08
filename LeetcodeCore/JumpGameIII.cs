using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class JumpGameIII
    {
        // 1306. Jump Game III
        public bool CanReach(int[] arr, int start)
        {
            var visited = new bool[arr.Length];
            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                visited[curr] = true;

                if (arr[curr] == 0)
                    return true;

                var p1 = curr - arr[curr];
                var p2 = curr + arr[curr];

                if (p1 >= 0 && !visited[p1])
                    queue.Enqueue(p1);
                if (p2 < arr.Length && !visited[p2])
                    queue.Enqueue(p2);
            }

            return false;
        }
    }
}
