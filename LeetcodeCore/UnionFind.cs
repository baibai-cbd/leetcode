using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    // Union-Find data structure and algorithm
    public class UnionFind
    {
        private int[] id;
        private int[] size;
        private int count;

        public UnionFind(int n)
        {
            count = n;
            id = new int[n];
            for (int i = 0; i < n; i++) id[i] = i;
            size = new int[n];
            for (int i = 0; i < n; i++) size[i] = 1;
        }

        public int Count()
            => count;

        public bool Connected(int p, int q)
            => Find(p) == Find(q);

        public int Find(int p)
        {
            while (p != id[p])
            {
                id[p] = id[id[p]];
                p = id[p];
            }
            return p;
        }

        public void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i == j)
                return;

            count--;
            if (size[i] < size[j])
            {
                id[i] = j;
                size[j] += size[i];
            }
            else
            {
                id[j] = i;
                size[i] += size[j];
            }
        }
    }
}
