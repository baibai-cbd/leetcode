using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RemoveKDigits
    {
        // 402. Remove K Digits
        public string RemoveKdigits(string num, int k)
        {
            if (num.Length <= k)
                return "0";

            while (k != 0)
            {
                var currIndex = 0;
                while (currIndex + 1 < num.Length && num[currIndex] - num[currIndex + 1] <= 0)
                {
                    currIndex++;
                }
                num = num.Remove(currIndex, 1);
                k--;
            }

            while (num.StartsWith('0'))
            {
                num = num.Remove(0, 1);
            }

            return num == "" ? "0" : num;
        }
    }
}
