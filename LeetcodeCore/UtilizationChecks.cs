using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class UtilizationChecks
    {
        public int FinalInstances(int instances, int[] averageUtil)
        {
            var scaledownConstant = 25;
            var scaleupConstant = 60;
            var index = 0;
            var result = instances;

            while (index < averageUtil.Length)
            {
                if (averageUtil[index] < scaledownConstant)
                {
                    if (result > 1)
                    {
                        result = result % 2 == 0 ? result / 2 : (result / 2) + 1;
                        index += 10;
                    }
                }
                else if (averageUtil[index] > scaleupConstant)
                {
                    if (result < 100000000)
                    {
                        result = result * 2;
                        index += 10;
                    }
                }
                index++;  // +10 +1 for scale up/down, or +1 for any other situations
            }

            return result;
        }
    }
}
