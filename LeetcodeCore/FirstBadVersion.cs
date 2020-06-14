using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class FirstBadVersionSolution
    {
        // 278. First Bad Version
        public int FirstBadVersion(int n)
        {
            if (IsBadVersion(1))
                return 1;

            int lastGood = 1;
            int firstBad = n;
            while (firstBad - lastGood > 1)
            {
                if (IsBadVersion(firstBad - (firstBad-lastGood)/2))
                {
                    firstBad = firstBad - (firstBad - lastGood) / 2;
                }
                else
                {
                    lastGood = firstBad - (firstBad - lastGood) / 2;
                }
            }
            return firstBad;
        }

        public bool IsBadVersion(int version)
        {
            throw new NotImplementedException();
        }
    }
}
