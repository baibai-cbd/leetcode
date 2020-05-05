using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class HappyNumber
    {
        // 202. Happy Number
        public bool IsHappy(int n)
        {
            var hs = new HashSet<int>();
            hs.Add(n);
            while (n != 1)
            {
                var result = 0;
                while (n != 0)
                {
                    result += (int)Math.Pow(n % 10, 2);
                    n /= 10;
                }
                if (hs.Contains(result))
                {
                    return false;
                }
                hs.Add(result);
                n = result;
            }
            return true;
        }
    }
}
