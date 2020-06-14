using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class ReverseStringSolution
    {
        // 344. Reverse String
        public void ReverseString(char[] s)
        {
            var i = 0;
            var j = s.Length - 1;
            while (i < j)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                i++;
                j--;
            }
        }
    }
}
