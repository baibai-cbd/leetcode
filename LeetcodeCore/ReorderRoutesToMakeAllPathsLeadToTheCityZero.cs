using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ReorderRoutesToMakeAllPathsLeadToTheCityZero
    {
        // 1466. Reorder Routes to Make All Paths Lead to the City Zero
        // BFS not very good
        public int MinReorder(int n, int[][] connections)
        {
            var count = 0;
            var undirectedLists = new HashSet<int>[n];
            var routeSet = new HashSet<string>(n);
            foreach (var item in connections)
            {
                routeSet.Add($"{item[0]},{item[1]}");
                if (undirectedLists[item[1]] == null) undirectedLists[item[1]] = new HashSet<int>();
                undirectedLists[item[1]].Add(item[0]);
                if (undirectedLists[item[0]] == null) undirectedLists[item[0]] = new HashSet<int>();
                undirectedLists[item[0]].Add(item[1]);
            }

            var queue = new Queue<(int, int)>();
            foreach (var node in undirectedLists[0]) queue.Enqueue((node, 0));

            while (queue.Count > 0)
            {
                var route = queue.Dequeue();
                if (!routeSet.Contains($"{route.Item1},{route.Item2}"))
                    count++;

                undirectedLists[route.Item1].Remove(route.Item2);
                undirectedLists[route.Item2].Remove(route.Item1);

                foreach (var node in undirectedLists[route.Item1])
                    queue.Enqueue((node, route.Item1));
            }

            return count;
        }
    }
}
