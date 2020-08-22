using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SortArrayByParitySolution
    {
        // 905. Sort Array By Parity
        public int[] SortArrayByParity(int[] A)
        {
            if (A.Length <= 1)
                return A;

            var i = 0;
            var j = A.Length - 1;

            while (i <= j)
            {
                if (A[i] % 2 == 0)
                {
                    i++;
                    continue;
                }
                if (A[j] % 2 == 1)
                {
                    j--;
                    continue;
                }
                var temp = A[i];
                A[i] = A[j];
                A[j] = temp;
            }
            return A;
        }
    }
}
