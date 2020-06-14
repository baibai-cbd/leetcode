using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class QueueReconstructionByHeight
    {
        // 406. Queue Reconstruction by Height
        // Not Optimal solution, look for better ones
        public int[][] ReconstructQueue(int[][] people)
        {
            if (people.Length == 0)
                return new int[0][];

            var result = new int[people.Length][];
            Array.Sort(people, (p1, p2) => p1[0] - p2[0]);

            var i = 1;
            var temp = new List<int[]>();
            temp.Add(people[0]);
            while (i < people.Length)
            {
                if (people[i][0] != temp[0][0]) 
                {
                    temp.Sort((p1, p2) => p1[1] - p2[1]);
                    PlacementHelper(result, temp);
                    temp = new List<int[]>();
                }
                temp.Add(people[i]);
                i++;
            }
            PlacementHelper(result, temp);
            return result;
        }

        private void PlacementHelper(int[][] array, IList<int[]> items)
        {
            foreach (var item in items)
            {
                var count = -1;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == null || array[i][0] >= item[0])
                        count++;
                    if (count == item[1])
                    {
                        array[i] = item;
                        break;
                    }
                }
            }
        }
    }
}
