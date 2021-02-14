using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class CourseScheduleMutation
    {
        // Course Schedule problem's mutation problem
        // print out all the tracks, a track means a route from start point course to end point course
        // start point course doesn't have any prerequisites, end point course doesn't have any ensuing courses
        public IList<List<string>> GetAllTracks(string[][] prerequisites)
        {
            var adjDict = new Dictionary<string, HashSet<string>>();
            foreach (var pair in prerequisites)
            {
                if (adjDict.ContainsKey(pair[1]))
                {
                    adjDict[pair[1]].Add(pair[0]);
                }
                else
                {
                    var hs = new HashSet<string>();
                    hs.Add(pair[0]);
                    adjDict.Add(pair[1], hs);
                }
            }

            var resultsList = new List<List<string>>();

            foreach (var course in adjDict.Keys)
            {
                if (!adjDict.Values.Any(hs => hs.Contains(course)))
                {
                    DFS(adjDict, resultsList, new List<string>(), course);
                }
            }

            return resultsList;
        }

        private void DFS(Dictionary<string, HashSet<string>> dict, List<List<string>> resultsList, List<string> currentList, string currentCourse)
        {
            if (!dict.ContainsKey(currentCourse))
            {
                // end of track
                resultsList.Add(new List<string>(currentList));
                return;
            }

            currentList.Add(currentCourse);

            // DFS
            foreach (var nextCourse in dict[currentCourse])
            {
                DFS(dict, resultsList, currentList, nextCourse);
            }

            currentList.RemoveAt(currentList.Count - 1);
        }
    }
}
