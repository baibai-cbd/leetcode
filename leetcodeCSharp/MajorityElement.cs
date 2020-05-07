using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class MajorityElementSolution
    {
        // 169. Majority Element
        public int MajorityElement(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            int majorityCount = nums.Length / 2;
            foreach (var i in nums)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i] += 1;
                    if (dict[i] > majorityCount)
                        return i;
                }
                else
                {
                    dict.Add(i, 1);
                }
            }
            return dict.Count == 1 ? dict.Keys.First() : int.MaxValue; // should not be int.Max ever
        }
    }
}
