using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class AccountsMergeSolution
    {
        // 721. Accounts Merge
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var graph = new Dictionary<string, ISet<string>>(); // email -> neighbor nodes
            var usernameDict = new Dictionary<string, string>(); // email -> username

            // build graph
            foreach (var a in accounts)
            {
                var username = a[0];
                for (int i = 1; i < a.Count; i++)
                {
                    usernameDict.TryAdd(a[i], username);
                    if (!graph.ContainsKey(a[i]))
                    {
                        graph.Add(a[i], new HashSet<string>());
                    }
                    if (i == 1)
                        continue;
                    // only add neighbors node because it's enough
                    graph.GetValueOrDefault(a[i]).Add(a[i - 1]); 
                    graph.GetValueOrDefault(a[i - 1]).Add(a[i]);
                }
            }

            // dfs
            var visitedSet = new HashSet<string>();
            var resultList = new List<IList<string>>();
            foreach (var email in graph.Keys)
            {
                var currList = new List<string>();
                if (visitedSet.Add(email))
                {
                    DFS(graph, email, visitedSet, currList);
                    currList.Sort(StringComparer.Ordinal);
                    currList.Insert(0, usernameDict.GetValueOrDefault(email));
                    resultList.Add(currList);
                }
            }

            return resultList;
        }

        private void DFS(Dictionary<string, ISet<string>> graph, string email, ISet<string> visited, IList<string> currList)
        {
            currList.Add(email);
            foreach (var node in graph.GetValueOrDefault(email))
            {
                if (visited.Add(node))
                {
                    DFS(graph, node, visited, currList);
                }
            }
        }
    }
}
