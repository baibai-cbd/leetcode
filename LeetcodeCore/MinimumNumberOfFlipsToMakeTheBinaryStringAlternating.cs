using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MinimumNumberOfFlipsToMakeTheBinaryStringAlternating
    {
        // 1888. Minimum Number of Flips to Make the Binary String Alternating
        // A sliding window solution by concat the string twice to form a "whole window" for sliding operation
        public int MinFlips(string s)
        {
            var newS = string.Concat(s, s);

            var flag = true;
            var sb = new StringBuilder();
            for (int k = 0; k <= newS.Length; k++)
            {
                sb.Append(flag ? '1' : '0');
                flag = !flag;
            }
            var mask1 = sb.ToString(0, newS.Length);
            sb.Remove(0, 1);
            var mask2 = sb.ToString();
            var count1 = 0;
            var count2 = 0;
            var minCount = s.Length;

            int i = 0;
            int j = 0;
            for (i = 0; i < newS.Length; i++)
            {
                while (i < s.Length)
                {
                    if (mask1[i] != newS[i])
                        count1++;
                    if (mask2[i] != newS[i])
                        count2++;
                    i++;
                }

                if (mask1[j] != newS[j])
                    count1--;
                if (mask1[i] != newS[i])
                    count1++;
                if (mask2[j] != newS[j])
                    count2--;
                if (mask2[i] != newS[i])
                    count2++;
                j++;
                minCount = Math.Min(minCount, Math.Min(count1, count2));
            }

            return minCount;
        }
    }
}
