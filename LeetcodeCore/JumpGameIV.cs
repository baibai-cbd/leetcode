using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class JumpGameIV
    {
        // 1345. Jump Game IV
        // BFS solution with some optimization
        public int MinJumps(int[] arr)
        {
            if (arr.Length == 1) return 0;
            if (arr[0] == arr[arr.Length - 1]) return 1;

            var groups = new Dictionary<int, HashSet<int>>();
            var queue = new Queue<int>();
            var visited = new bool[arr.Length];
            var count = 0;
            var lastIndex = arr.Length - 1;

            groups.Add(arr[0], new HashSet<int>());
            groups[arr[0]].Add(0);
            groups.Add(arr[lastIndex], new HashSet<int>());
            groups[arr[lastIndex]].Add(lastIndex);
            for (int i = 1; i < lastIndex; i++)
            {
                // This part is an important optimization,
                // if one index has same value with both previous and next index, there's no need to add it to the adjacent group
                if (arr[i] == arr[i - 1] && arr[i] == arr[i + 1])
                {
                    continue;
                }
                else if (groups.ContainsKey(arr[i]))
                {
                    groups[arr[i]].Add(i);
                }
                else
                {
                    groups.Add(arr[i], new HashSet<int>());
                    groups[arr[i]].Add(i);
                }
            }

            queue.Enqueue(0);
            visited[0] = true;
            while (queue.Count > 0)
            {
                var currQueue = queue.Count;
                count++;
                for (int i = 1; i <= currQueue; i++)
                {
                    var currIndex = queue.Dequeue();
                    if (currIndex + 1 == lastIndex || groups[arr[currIndex]].Contains(lastIndex))
                        return count;

                    if (currIndex + 1 < arr.Length && !visited[currIndex + 1])
                    {
                        visited[currIndex + 1] = true;
                        queue.Enqueue(currIndex + 1);
                    }

                    if (currIndex - 1 >= 0 && !visited[currIndex - 1])
                    {
                        visited[currIndex - 1] = true;
                        queue.Enqueue(currIndex - 1);
                    }

                    foreach (var p in groups[arr[currIndex]])
                    {
                        if (!visited[p])
                        {
                            visited[p] = true;
                            queue.Enqueue(p);
                        }
                    }
                }
            }
            return -1;
        }
    }
}
