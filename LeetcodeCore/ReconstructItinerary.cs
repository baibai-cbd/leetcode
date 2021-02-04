using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class ReconstructItinerary
    {
        // 332. Reconstruct Itinerary
        // Brute force DFS would timeout, building a graph first is necessary
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var adjLists = new Dictionary<string, List<string>>();
            var results = new LinkedList<string>();

            foreach (var item in tickets)
            {
                if (!adjLists.ContainsKey(item[0]))
                {
                    var newList = new List<string>();
                    newList.Add(item[1]);
                    adjLists.Add(item[0], newList);
                }
                else
                {
                    adjLists[item[0]].Add(item[1]);
                }
            }
            foreach (var key in adjLists.Keys)
            {
                adjLists[key].Sort(); // sort here can ensure least lexicographic result will be produced
            }
            //
            var startVertex = "JFK";
            var madeTrips = 0;
            var totalTrips = tickets.Count;
            results.AddLast(startVertex);
            DFSFind(adjLists, results, startVertex, ref madeTrips, totalTrips);
            //
            return results.ToList();
        }

        private void DFSFind(IDictionary<string, List<string>> dict, LinkedList<string> result, string currVertex, ref int madeTrips, int totalTrips)
        {
            if (!dict.ContainsKey(currVertex))
                return;

            var neighbors = dict[currVertex];
            for (int i = 0; i < neighbors.Count; i++)
            {
                var next = neighbors[i];
                neighbors.RemoveAt(i);
                madeTrips++;
                result.AddLast(next);
                //
                // the ref madeTrips count is important because once we find the result, we want return all the way
                // not running any of that restoring code.
                DFSFind(dict, result, next, ref madeTrips, totalTrips);
                //
                if (madeTrips == totalTrips)
                    return;
                //
                neighbors.Insert(i, next);
                madeTrips--;
                result.RemoveLast();
            }
        }
    }
}
