using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class PermutationInString
    {
        // 567. Permutation in String
        // Sliding Window method
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length == 0 || s2.Length == 0 || s2.Length < s1.Length)
                return false;

            var chars = new int[26];
            foreach (var c in s1)
                chars[c - 'a']++;

            var start = 0;
            var end = 0;
            var length = s1.Length;
            var diff = length;
            char currChar;

            for (end = 0; end < length; end++)
            {
                currChar = s2[end];
                chars[currChar - 'a']--;
                if (chars[currChar - 'a'] >= 0)
                    diff--;
            }

            if (diff == 0)
                return true;

            while (end < s2.Length)
            {
                currChar = s2[start];
                if (chars[currChar - 'a'] >= 0)
                    diff++;

                chars[currChar - 'a']++;

                start++;
                //
                currChar = s2[end];
                chars[currChar - 'a']--;
                if (chars[currChar - 'a'] >= 0)
                    diff--;

                if (diff == 0)
                    return true;

                end++;
            }
            return false;
        }
    }
}
