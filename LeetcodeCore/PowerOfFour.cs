using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class PowerOfFour
    {
        // 342. Power of Four
        public bool IsPowerOfFour(int num)
        {
            int mask = 0b0101_0101_0101_0101_0101_0101_0101_0101;

            int bitOr = num | mask;
            if (bitOr != mask)
                return false;

            int bitAnd = num & mask;
            string rb = Convert.ToString(bitAnd, 2);
            var count = 0;
            for (int i = 0; i < rb.Length; i++)
            {
                if (rb[i] == '1')
                    count++;
            }
            return count == 1;
        }
    }
}
