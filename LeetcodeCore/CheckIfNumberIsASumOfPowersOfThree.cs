using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class CheckIfNumberIsASumOfPowersOfThree
    {
        // 1780. Check if Number is a Sum of Powers of Three
        public bool CheckPowersOfThree(int n)
        {
            var powersOf3 = new int[15];

            for (int i = 0, p = 1; i < 15; ++i, p *= 3)
            {
                powersOf3[i] = p;
            }

            for (int i = 14; i >= 0 && n > 0; --i)
            {
                if (n >= powersOf3[i])
                {
                    n -= powersOf3[i];
                }
            }
            return n == 0;
        }
    }
}
