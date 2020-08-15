using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class LongestPalindromeSolution
    {
        // 409. Longest Palindrome
        public int LongestPalindrome(string s)
        {
            int[] array = new int[58];
            for (int i = 0; i < s.Length; i++)
            {
                array[s[i] - 'A']++;
            }

            int result = 0;
            bool flag = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                    result += array[i];
                else
                {
                    flag = true;
                    result += array[i] - 1;
                }
            }
            result = flag ? result + 1 : result; // result++ in ternary operator won't work
            return result;
        }
    }
}
