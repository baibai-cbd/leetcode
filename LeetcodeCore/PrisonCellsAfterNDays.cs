using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class PrisonCellsAfterNDays
    {
        // 957. Prison Cells After N Days
        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            var dict = new Dictionary<string, int>();
            dict.Add(ArrayToString(cells), 0);

            var currCells = cells;
            var count = 1;
            while (true)
            {
                var newCells = new int[cells.Length];
                newCells[0] = 0;
                newCells[newCells.Length - 1] = 0;
                for (int i = 1; i < newCells.Length -1; i++)
                {
                    newCells[i] = currCells[i - 1] == currCells[i + 1] ? 1 : 0;
                }
                if (N == count)
                {
                    return newCells;
                }
                if (dict.TryGetValue(ArrayToString(newCells), out int j))
                {
                    var cycle = count - j;
                    var index = (N - j) % cycle;
                    var resultString = dict.Where(kvp => kvp.Value == j + index).FirstOrDefault().Key;
                    return StringToArray(resultString);
                }
                else
                {
                    dict.Add(ArrayToString(newCells), count);
                    currCells = newCells;
                    count++;
                }
            }
        }

        private string ArrayToString(int[] array)
        {
            var sb = new StringBuilder();
            foreach (var i in array)
            {
                sb.Append(i);
            }
            return sb.ToString();
        }

        private int[] StringToArray(string s)
        {
            var arr = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = int.Parse(s.Substring(i, 1));
            }
            return arr;
        }
    }
}
