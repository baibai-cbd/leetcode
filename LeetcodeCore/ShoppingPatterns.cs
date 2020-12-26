using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class ShoppingPatterns
    {
        public int GetMinimumScore(int productNodes, int[] productsFrom, int[] productsTo)
        {
            HashSet<int>[] edges = new HashSet<int>[productNodes + 1];
            for (int i = 1; i < edges.Length; i++)
            {
                edges[i] = new HashSet<int>();
            }

            for (int i = 0; i < productsFrom.Length; i++)
            {
                var fromIndex = productsFrom[i];
                var toIndex = productsTo[i];
                edges[fromIndex].Add(toIndex);
                edges[toIndex].Add(fromIndex);
            }

            int result = int.MaxValue;
            for (int i = 1; i < edges.Length; i++)
            {
                if (edges[i].Count > 1)
                {
                    var list = edges[i].ToList();
                    for (int j = 0; j < list.Count; j++)
                    {
                        for (int k = j+1; k < list.Count; k++)
                        {
                            if (edges[list[j]].Contains(list[k])) // mind the indexes
                            {
                                // trio found
                                var currCost = edges[i].Count + edges[list[j]].Count + edges[list[k]].Count - 6; // mind the indexes
                                result = Math.Min(result, currCost);
                            }
                        }
                    }
                }
            }
            return result == int.MaxValue ? -1 : result;
        }
    }
}
