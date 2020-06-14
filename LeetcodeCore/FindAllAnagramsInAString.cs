using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeCore
{
    public class FindAllAnagramsInAString
    {
        // 438. Find All Anagrams in a String
        // Sliding Window Method
        // VERY IMPORTANT!!!
        public IList<int> FindAnagrams(string s, string p) 
        {
            var sln = new List<int>();

            if (s.Length == 0 || p.Length == 0 || s.Length < p.Length)
                return sln;

            var chars = new int[26];
            foreach (var c in p)
                chars[c - 'a']++;

            var start = 0;
            var end = 0;
            var length = p.Length;
            var diff = length;
            char currChar;

            for (end = 0; end < length; end++)
            {
                currChar = s[end];
                chars[currChar - 'a']--;
                if (chars[currChar - 'a'] >= 0)
                    diff--;
            }

            if (diff == 0)
                sln.Add(start);

            while (end < s.Length)
            {
                currChar = s[start];
                if (chars[currChar - 'a'] >= 0)
                    diff++;

                chars[currChar - 'a']++;

                start++;
                //
                currChar = s[end];
                chars[currChar - 'a']--;
                if (chars[currChar - 'a'] >= 0)
                    diff--;

                if (diff == 0)
                    sln.Add(start);

                end++;
            }
            return sln;
        }
    }
}
