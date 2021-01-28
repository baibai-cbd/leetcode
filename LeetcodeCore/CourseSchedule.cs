using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class CourseSchedule
    {
        // 207. Course Schedule
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var adjLists = new List<IList<int>>(numCourses);
            for (int i = 0; i < numCourses; i++)
            {
                adjLists.Add(new List<int>(numCourses));
            }
            foreach (var item in prerequisites)
            {
                adjLists[item[1]].Add(item[0]);
            }

            var visited = new bool[numCourses];
            var recStack = new bool[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                if (HasCycleUtil(adjLists, i, visited, recStack))
                    return false;
            }
            return true;
        }

        private bool HasCycleUtil(IList<IList<int>> adjLists, int i, bool[] visited, bool[] recStack)
        {
            if (recStack[i])
                return true;
            if (visited[i])
                return false;

            visited[i] = true;
            recStack[i] = true;

            foreach (var item in adjLists[i])
            {
                if (HasCycleUtil(adjLists, item, visited, recStack))
                    return true;
            }

            recStack[i] = false;
            return false;
        }
    }

    public class CourseScheduleWithTopologicalSort
    {
        // Topological Sort
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var adjLists = new List<IList<int>>(numCourses);
            for (int i = 0; i < numCourses; i++)
            {
                adjLists.Add(new List<int>(numCourses));
            }
            foreach (var item in prerequisites)
            {
                adjLists[item[1]].Add(item[0]);
            }

            var visited = new bool[numCourses];
            var stack = new Stack<int>();

            for (int i = 0; i < numCourses; i++)
            {
                if (!visited[i])  // before call DFS, check visited
                    DFSTopologicalSort(adjLists, visited, stack, i);
            }

            var resultDict = new Dictionary<int, int>();
            for (int i = 0; i < numCourses; i++)
            {
                resultDict.Add(stack.Pop(), i);
            }

            if (prerequisites.Any(pair => resultDict[pair[0]] < resultDict[pair[1]]))
            {
                return false;
            }

            return true;
        }

        private void DFSTopologicalSort(IList<IList<int>> adjLists, bool[] visited, Stack<int> stack, int currVertex)
        {
            // if here we don't check visited, then before every call to DFS should check visited
            visited[currVertex] = true;

            foreach (var edge in adjLists[currVertex])
            {
                if (!visited[edge])  // before call DFS, check visited
                    DFSTopologicalSort(adjLists, visited, stack, edge);
            }

            stack.Push(currVertex);
        }
    }
}
