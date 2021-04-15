using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ReverseWordsInAStringII
    {
        // 186. Reverse Words in a String II
        public void ReverseWords(char[] s)
        {
            Array.Reverse(s);
            var i = 0;
            var j = 0;

            while (j < s.Length)
            {
                if (char.IsWhiteSpace(s[j]))
                {
                    if (char.IsLetterOrDigit(s[i])) Array.Reverse(s, i, j - i);
                    i = j;
                    j++;
                }
                else if (char.IsLetterOrDigit(s[j]))
                {
                    if (char.IsWhiteSpace(s[i])) i = j;
                    j++;
                }
            }
            Array.Reverse(s, i, j - i);
        }
    }
}
