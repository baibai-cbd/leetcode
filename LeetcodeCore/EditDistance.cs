using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class EditDistance
    {
        // 72. Edit Distance
        public int MinDistance(string word1, string word2)
        {
            if (word1.Length == 0) return word2.Length;
            if (word2.Length == 0) return word1.Length;

            int m = word1.Length + 1;
            int n = word2.Length + 1;

            int[,] DP = new int[m, n];

            DP[0, 0] = 0;

            for (int i = 1; i < m; i++)
                DP[i, 0] = i;

            for (int i = 1; i < n; i++)
                DP[0, i] = i;

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    int min = Math.Min(DP[i - 1, j - 1], Math.Min(DP[i - 1, j], DP[i, j - 1]));
                    if (word1[i - 1] == word2[j - 1])
                        DP[i, j] = DP[i - 1, j - 1];
                    else
                        DP[i, j] = min + 1;
                }
            }
            return DP[m - 1, n - 1];
        }
    }
}
