using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ReverseWordsInAString
    {
        // 151. Reverse Words in a String
        // TODO: try O(1) extra space method next time
        public string ReverseWords(string s)
        {
            var sb = new StringBuilder();
            var s1 = s.Trim();
            var list = s1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = list.Length - 1; i >= 0; i--)
            {
                sb.Append(list[i]);
                sb.Append(" ");
            }
            return sb.ToString().Trim();
        }
    }
}
