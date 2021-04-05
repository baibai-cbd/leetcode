using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class IsomorphicStrings
    {
        // 205. Isomorphic Strings
        public bool IsIsomorphic(string s, string t)
        {
            var mapping1 = new int[256];
            var mapping2 = new int[256];
            Array.Fill(mapping1, -1);
            Array.Fill(mapping2, -1);

            for (int i = 0; i < s.Length; i++)
            {
                if (mapping1[(int)s[i]] == -1 && mapping2[(int)t[i]] == -1)
                {
                    mapping1[(int)s[i]] = (int)t[i];
                    mapping2[(int)t[i]] = (int)s[i];
                }
                else if (mapping1[(int)s[i]] != (int)t[i] || mapping2[(int)t[i]] != (int)s[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
