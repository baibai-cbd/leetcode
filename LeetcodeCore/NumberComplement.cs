using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class NumberComplement
    {
        // 1009. Complement of Base 10 Integer
        public int FindComplement(int num)
        {
            var mask = 1;
            var input = num;
            while (input > 1)
            {
                input >>= 1;
                mask = (mask << 1) + 1;
            }
            return num ^ mask;
        }
    }
}
