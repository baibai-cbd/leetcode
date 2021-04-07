using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class GraphValidTree
    {
        // 261. Graph Valid Tree
        // Ridiculously easy with UnionFind
        public bool ValidTree(int n, int[][] edges)
        {
            var uf = new UnionFind(n);

            foreach (var e in edges)
            {
                if (uf.Connected(e[0], e[1]))
                    return false;

                uf.Union(e[0], e[1]);
            }

            return uf.Count() == 1;
        }
    }
}
