using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class ContiguousArray
    {
        // 525. Contiguous Array
        public int FindMaxLength(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            dict.Add(0, -1);

            var sum = 0;
            var maxSpan = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i] == 0 ? -1 : 1;
                if (dict.TryGetValue(sum, out int value))
                {
                    maxSpan = Math.Max(maxSpan, i - value);
                }
                else
                {
                    dict.Add(sum, i);
                }
            }
            return maxSpan;
        }
    }
}
