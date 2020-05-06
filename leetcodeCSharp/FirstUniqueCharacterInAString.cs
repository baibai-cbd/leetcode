using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcodeCSharp
{
    public class FirstUniqueCharacterInAString
    {
        // 387. First Unique Character in a String
        public int FirstUniqChar(string s)
        {
            int[] freqArray = new int[26];
            int firstIndex = s.Length;
            foreach (var c in s)
                freqArray[c - 'a']++;
            for (int i = 0; i < freqArray.Length; i++)
            {
                if (freqArray[i]==1)
                    firstIndex = Math.Min(firstIndex, s.IndexOf((char)('a' + i)));
            }

            return firstIndex == s.Length ? -1 : firstIndex;
        }
    }
}
