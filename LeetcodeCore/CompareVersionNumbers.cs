using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    // 165. Compare Version Numbers
    public class CompareVersionNumbers
    {
        public int CompareVersion(string version1, string version2)
        {
            var arr1 = version1.Split('.');
            var numArr1 = arr1.Select(s => int.Parse(s)).ToArray();
            var arr2 = version2.Split('.');
            var numArr2 = arr2.Select(s => int.Parse(s)).ToArray();

            int round = Math.Min(arr1.Length, arr2.Length);
            for (int i = 0; i < round; i++)
            {
                if (numArr1[i] > numArr2[i])
                {
                    return 1;
                }
                if (numArr1[i] < numArr2[i])
                {
                    return -1;
                }
            }

            if (numArr1.Length == numArr2.Length)
            {
                return 0;
            } 
            else if (numArr1.Length > numArr2.Length)
            {
                for (int j = round; j < numArr1.Length; j++)
                {
                    if (numArr1[j] > 0)
                        return 1;
                }
            }
            else
            {
                for (int k = round; k < numArr2.Length; k++)
                {
                    if (numArr2[k] > 0)
                        return -1;
                }
            }

            return 0;
        }
    }
}
