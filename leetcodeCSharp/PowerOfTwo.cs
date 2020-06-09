using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class PowerOfTwo
    {
        // 231. Power of Two
        public bool IsPowerOfTwo(int n)
        {
            int temp = 1;
            for (int i = 0; i <= 30; i++)
            {
                if (n == temp)
                    return true;
                temp = temp << 1;
            }
            return false;
        }
    }
}
