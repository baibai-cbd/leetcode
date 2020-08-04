using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ValidPalindrome
    {
        // 125. Valid Palindrome
        public bool IsPalindrome(string s)
        {
            var st = s.Trim();
            var stl = st.ToLower();
            int i = 0;
            int j = stl.Length - 1;

            while (i < j)
            {
                while (!char.IsLetterOrDigit(stl[i]) && i < j)
                    i++;
                while (!char.IsLetterOrDigit(stl[j]) && i < j)
                    j--;
                if (i == j)
                    return true;
                if (stl[i] != stl[j])
                    return false;
                i++;
                j--;
            }
            return true;
        }
    }
}
