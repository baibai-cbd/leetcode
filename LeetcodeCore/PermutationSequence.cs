using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeCore
{
    public class PermutationSequence
    {
        // 60. Permutation Sequence
        public string GetPermutation(int n, int k)
        {
            var resultList = new List<int>();
            var index = k - 1;
            var array = new List<int>();
            for (int i = 1; i <= n; i++)
                array.Add(i);

            while (resultList.Count < n)
            {
                var factorial = Factorial(array.Count - 1);
                var quotient = index / factorial;
                resultList.Add(array.ElementAt(quotient));
                array.RemoveAt(quotient);
                index = index % factorial;
            }

            var sb = new StringBuilder();
            foreach (var item in resultList)
                sb.Append(item);

            return sb.ToString();
        }

        private int Factorial(int n)
        {
            int res = 1;
            while (n >= 1)
            {
                res = res * n;
                n = n - 1;
            }
            return res;
        }
    }
}
