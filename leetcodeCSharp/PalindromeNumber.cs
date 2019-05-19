using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class PalindromeNumber
    {
        // 9. Palindrome Number

        public static bool IsPalindrome(int x)
        {
            if (x<0)
			    return false;

            List<int> list = new List<int>();
            int temp = x;

            while (temp >= 10)
            {
                list.Add(temp % 10);
                temp = temp / 10;
            }
            list.Add(temp);

            int result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                result = result * 10;
                result += list.ElementAt(i);
            }
            
            return (result-x)==0 ? true : false;
        }
    }
}
