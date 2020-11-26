using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class UglyNumber
    {
        // 263. Ugly Number
        public bool IsUgly(int num)
        {
            while (true)
            {
                var currNum = num;
                if (num % 2 == 0)
                {
                    num = num / 2;
                }
                if (num % 3 == 0)
                {
                    num = num / 3;
                }
                if (num % 5 == 0)
                {
                    num = num / 5;
                }

                if (currNum == num)
                {
                    return currNum == 1;
                }
            }
        }
    }
}
