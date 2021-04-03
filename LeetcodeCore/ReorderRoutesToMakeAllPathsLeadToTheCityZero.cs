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


        // DFS solution
        // slightly better than BFS
        HashSet<int>[] fromLists;
        HashSet<int>[] toLists;

        public int MinReorder2(int n, int[][] connections)
        {
            var count = 0;
            fromLists = new HashSet<int>[n];
            toLists = new HashSet<int>[n];
            foreach (var item in connections)
            {
                if (fromLists[item[1]] == null) fromLists[item[1]] = new HashSet<int>();
                fromLists[item[1]].Add(item[0]);
                if (toLists[item[0]] == null) toLists[item[0]] = new HashSet<int>();
                toLists[item[0]].Add(item[1]);
            }

            DFS(0, ref count);

            return count;
        }

        private void DFS(int v, ref int count)
        {
            if (toLists[v] != null)
            {
                foreach (var node in toLists[v])
                {
                    count++;
                    fromLists[node].Remove(v);
                    DFS(node, ref count);
                }
            }
            if (fromLists[v] != null)
            {
                foreach (var node in fromLists[v])
                {
                    toLists[node].Remove(v);
                    DFS(node, ref count);
                }
            }
        }
    }
}
