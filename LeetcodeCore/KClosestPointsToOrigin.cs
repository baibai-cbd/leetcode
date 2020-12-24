using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class KClosestPointsToOrigin
    {
        // 973. K Closest Points to Origin
        // Using a priority queue is not inherently better than simply sorting,
        // sorting is O(nlogn) complexity while insert in priority queue is O(logn), 
        // but we have to go thru the whole array, so the overall complexity is the same.
        public int[][] KClosest(int[][] points, int K)
        {
            var comparer = Comparer<int[]>.Create((p1, p2) => (p1[0] * p1[0] + p1[1] * p1[1]) - (p2[0] * p2[0] + p2[1] * p2[1]));
            Array.Sort(points, comparer);
            var results = new int[K][];
            Array.Copy(points, results, K);
            return results;
        }
    }
}
