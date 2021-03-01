using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class Combinations
    {
        // 77. Combinations
        // TODO: Try backtracking
        public IList<IList<int>> Combine(int n, int k)
        {
            var results = new List<IList<int>>();
            DFS(results, new List<int>(), n, k, 1);
            return results;
        }

        private void DFS(IList<IList<int>> results, IList<int> currList, int n, int k, int index)
        {
            if (currList.Count == k)
            {
                results.Add(new List<int>(currList));
                return;
            }

            if (index > n)
                return;

            DFS(results, currList, n, k, index + 1);
            currList.Add(index);
            DFS(results, currList, n, k, index + 1);
            currList.RemoveAt(currList.Count - 1);
        }


        // Backtracking
        // backtracking usually use a loop over the next step options, 
        // add the element to the current result set, then recursively call,
        // remove the current element after the recursive call returns
        public IList<IList<int>> Combine2(int n, int k)
        {
            var results = new List<IList<int>>();
            Backtrack(results, new List<int>(), n, k, 1);
            return results;
        }

        private void Backtrack(IList<IList<int>> results, IList<int> currList, int n, int k, int index)
        {
            if (currList.Count == k)
            {
                results.Add(new List<int>(currList));
                return;
            }

            for (int i = index; i <= n; i++)
            {
                currList.Add(i);
                Backtrack(results, currList, n, k, i + 1);
                currList.RemoveAt(currList.Count - 1);
            }
        }
    }
}
