using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class RomanToInteger
    {
        // 13. Roman to Integer
        private readonly IDictionary<char, int> _dict = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public int RomanToInt(string s)
        {
            var result = 0;
            var lastLookup = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                _dict.TryGetValue(s[i], out int currLookup);
                if (currLookup < lastLookup)
                {
                    result -= currLookup;
                }
                else
                {
                    result += currLookup;
                }
                lastLookup = currLookup;
            }
            return result;
        }
    }
}
