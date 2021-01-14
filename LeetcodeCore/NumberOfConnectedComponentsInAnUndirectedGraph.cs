using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class NumberOfConnectedComponentsInAnUndirectedGraph
    {
        // 323. Number of Connected Components in an Undirected Graph
        public int CountComponents(int n, int[][] edges)
        {
            // construct graph
            HashSet<int>[] nodes = new HashSet<int>[n];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new HashSet<int>();
            }
            foreach (var item in edges)
            {
                nodes[item[0]].Add(item[1]);
                nodes[item[1]].Add(item[0]);
            }

            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            var result = 0;

            for (int i = 0; i < nodes.Length; i++)
            {
                if (!visited.Contains(i))
                {
                    result++;
                    queue.Enqueue(i);
                    while (queue.Count > 0)
                    {
                        var currNode = queue.Dequeue();
                        visited.Add(currNode);
                        foreach (var e in nodes[currNode])
                        {
                            if (!visited.Contains(e))
                            {
                                queue.Enqueue(e);
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
